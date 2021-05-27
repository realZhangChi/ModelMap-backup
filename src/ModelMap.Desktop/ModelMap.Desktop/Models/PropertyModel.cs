//using ModelMap.Diagrams;
//using System.Text.Json.Serialization;

//namespace ModelMap.Desktop.Models
//{
//    public class PropertyModel : PropertyDefineDto
//    {
//        // TODO: set value asynchronously https://stackoverflow.com/questions/6602244/how-to-call-an-async-method-from-a-getter-or-setter
//        // TODO: Operate the collapse style via js
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
//        }
//    }
//}
