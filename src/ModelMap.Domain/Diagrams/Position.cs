using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Values;

namespace ModelMap.Diagrams
{
    public class Position : ValueObject
    {
        [Required]
        public double Top { get; private set; }

        [Required]
        public double Left { get; private set; }

        protected Position()
        {

        }

        protected internal Position(double top, double left)
        {
            Top = top;
            Left = left;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Top;
            yield return Left;
        }
    }
}
