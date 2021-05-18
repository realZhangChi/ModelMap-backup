using JetBrains.Annotations;
using ModelMap.Solutions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity.PlugIns;

namespace ModelMap.Desktop.Services.Solution
{
    public class SolutionService : ISolutionService, ITransientDependency
    {
        private readonly string[] _foldersToIgnore = {
            "bin",
            "obj",
            "Properties"
        };

        private readonly ICurrentSolution _currentSolution;

        public SolutionService(ICurrentSolution currentSolution)
        {
            _currentSolution = currentSolution;
        }

        public Task<string> GetNamespaceAsync([NotNull] string csFileDirectory)
        {
            return Task.Run(() =>
            {
                var project = _currentSolution.Value.Projects
                    .Where(p => csFileDirectory.StartsWith(Path.GetDirectoryName(p.FilePath))).SingleOrDefault();

                if (project is null)
                {
                    // TODO: throw exception
                }

                var folders = csFileDirectory
                    .Substring(Path.GetDirectoryName(project.FilePath).Length).RemovePreFix(Path.DirectorySeparatorChar.ToString())
                    .Split(Path.DirectorySeparatorChar).ToList();
                folders.RemoveAll(f => string.IsNullOrWhiteSpace(f));
                var csNamespace = project.DefaultNamespace;
                foreach (var folder in folders)
                {
                    csNamespace += $".{folder}";
                }
                return csNamespace;
            });
        }

        public Task<string> GetProjectRelativePathAsync([NotNull] string path)
        {
            return Task.Run(() =>
            {
                var project = _currentSolution.Value.Projects
                    .Where(p => path.StartsWith(Path.GetDirectoryName(p.FilePath))).SingleOrDefault();
                return Path.GetRelativePath(Path.GetDirectoryName(_currentSolution.Value.FilePath), project.FilePath);
            });
        }

        // TODO: get model from ICurrentSolution
        public Task<SolutionTreeDto> GetSolutionModelAsync([NotNull] string path)
        {
            var directory = Path.GetDirectoryName(path);
            var root = new TreeNodeDto()
            {
                Path = directory,
                Name = Path.GetFileName(directory),
                IsFile = (System.IO.File.GetAttributes(directory) & FileAttributes.Directory) == 0,
                Children = new List<TreeNodeDto>()
            };
            SetChildren(root);
            var solution = new SolutionTreeDto()
            {
                RootNode = root
            };
            return Task.FromResult(solution);
        }

        private void SetChildren(TreeNodeDto node)
        {
            if (node.IsFile)
            {
                return;
            }

            var directories = Directory.GetDirectories(node.Path);
            foreach (var directory in directories)
            {
                var directoryName = Path.GetFileName(directory);
                if (directoryName.StartsWith('.') || _foldersToIgnore.Contains(directoryName))
                {
                    continue;
                }
                var directoryChild = new TreeNodeDto()
                {
                    Path = directory,
                    Name = Path.GetFileName(directory),
                    IsFile = (System.IO.File.GetAttributes(directory) & FileAttributes.Directory) == 0,
                    Children = new List<TreeNodeDto>()
                };
                SetChildren(directoryChild);
                node.Children.Add(directoryChild);
            }

            var files = Directory.GetFiles(node.Path);
            foreach (var file in files)
            {
                if (Path.GetFileName(file).StartsWith('.'))
                {
                    continue;
                }
                node.Children.Add(new TreeNodeDto()
                {
                    Path = file,
                    Name = Path.GetFileName(file),
                    IsFile = (System.IO.File.GetAttributes(file) & FileAttributes.Directory) == 0,
                    Children = new List<TreeNodeDto>()
                });
            }
        }
    }
}
