using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scripts
{
    public class DialogTree
    {
        public virtual bool IsAvailable(Context context) { return context.MeetsPredicates(PredicateIds) && context.TreeUnexplored(this); }
        public DialogNode RootStatement { get; set; }
        [XmlAttribute]
        public string Hint { get; set; }
        [XmlAttribute]
        public string PredicateIdString {
            get{
                if(PredicateIds != null) {
                    return String.Join(",", PredicateIds);
                } else {
                    return "";
                }
            }
            set{ PredicateIds = value.Split(','); }
        }

        public string[] PredicateIds { get; set; }

        public override string ToString()
        {
            return "Hint: " + Hint + "\nPredicateIds: " + PredicateIdString + "\nNode:" + RootStatement.ToString();
        }
    }
}
