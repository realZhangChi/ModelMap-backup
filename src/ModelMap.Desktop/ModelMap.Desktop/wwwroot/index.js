
export function selectSolution() {
    console.log('selectSolution');
    return new Promise((function (resolve, reject) {
        try {
            let solutionInput = document.createElement('input');
            solutionInput.type = 'file';
            solutionInput.accept = '.sln';
            solutionInput.onchange = _ => {
                if (solutionInput.files && solutionInput.files.length > 0) {
                    console.log(solutionInput.files);
                    console.log(solutionInput.files[0]);
                    console.log(solutionInput.files[0].path);
                    resolve(solutionInput.files[0].path);
                } else {
                    reject('No solution selected');
                }
            }
            solutionInput.click();
        }
        catch (e) {
            reject(e);
        }
    }));
}