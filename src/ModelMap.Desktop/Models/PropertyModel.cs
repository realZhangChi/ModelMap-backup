//using MarauderMap.SourceEntries;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;

//namespace ModelMap.Desktop.Models
//{
//    public class PropertyModel : PropertyDto
//    {
//        // TODO: set value asynchronously https://stackoverflow.com/questions/6602244/how-to-call-an-async-method-from-a-getter-or-setter
//        private const string CollapseHide = "collapse";
//        private const string CollapseHiding = "collapsing";
//        private const string CollapseShowing = "collapsing show";
//        private const string CollapseShow = "collapse show";
//        [JsonIgnore]
//        public string CollapseStyle => Collapse ? CollapseShow : CollapseHide;

//        private const string CollapseHiddenIconStyle = "fa-angle-right";
//        private const string CollapseShowIconStyle = "fa-angle-down";
//        [JsonIgnore]
//        public string CollapseIconStyle => Collapse ? CollapseShowIconStyle : CollapseHiddenIconStyle;

//        [JsonIgnore]
//        public bool Collapse { get; set; }

//        public PropertyModel()
//        {
//            AccessLevel = "public";
//        }
//    }
//}
