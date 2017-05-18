<%==SIM:ExplicitLinesOn==%>
<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
using NHibernate;<%==SIM:Line==%>
using NHibernate.Criterion;<%==SIM:Line(2)==%>

namespace <%==SIM:Element.Namespace==%><%==SIM:Line==%>
{<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    public class <%==SIM:Element.Name==%><%==SIM:Line==%>
    {<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes==%>
        public virtual <%==SIM:Attribute.TypeName==%><%==SIM:IfNot:Attribute.ReplacedType.IsNullable==%><%==SIM:If:Attribute.IsNullable==%>?<%==SIM:EndIf==%><%==SIM:EndIf==%> <%==SIM:Attribute.Name==%> { get; set; }
<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.InverseReferences==%>
        public virtual IList<<%==SIM:Reference.ForeignKeyEntity.Name==%>> <%==SIM:Reference.Name==%>;
<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>
        public <%==SIM:Element.Name==%>()<%==SIM:Line==%>
        {<%==SIM:Line==%>
<%==SIM:ForEach:Element.InverseReferences==%>
            <%==SIM:Reference.Name==%> = new List<<%==SIM:Reference.ForeignKeyEntity.Name==%>>();
<%==SIM:Line==%>
<%==SIM:EndFor==%>
        }<%==SIM:Line==%>
<%==SIM:Line==%>

<%==SIM:If:GreaterThan(Element.PrimaryKeys.Count,1)==%>
        public override bool Equals(object obj)<%==SIM:Line==%>
        {<%==SIM:Line==%>
            if (obj == null || GetType() != obj.GetType()) return false;<%==SIM:Line==%>
            <%==SIM:Element.Name==%> other = (<%==SIM:Element.Name==%>)obj;<%==SIM:Line==%><%==SIM:Line==%>
            if (<%==SIM:ForEach:Element.PrimaryKeys==%> this.<%==SIM:Key.Name==%> == other.<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%> && <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:Line==%>
                return true;<%==SIM:Line==%>
            else<%==SIM:Line==%>
                return false;<%==SIM:Line==%>
        }<%==SIM:Line==%>
        <%==SIM:Line==%>
        public override int GetHashCode()<%==SIM:Line==%>
        {<%==SIM:Line==%>
            return <%==SIM:ForEach:Element.PrimaryKeys==%> this.<%==SIM:Key.Name==%>.GetHashCode()<%==SIM:IfNot:IsLastItem==%> + <%==SIM:EndIf==%><%==SIM:EndFor==%>;
            <%==SIM:Line==%>
        }<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:Line==%>

    }<%==SIM:Line==%>
}<%==SIM:Line==%>
