using JetBrains.Annotations;
using ModelMap.Solutions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.Solution
{
    public class SolutionService : ISolutionService, ITransientDependency
    {
        private readonly string[] _foldersToIgnore = {
            "bin",
            "obj",
            "Properties"
        };

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
