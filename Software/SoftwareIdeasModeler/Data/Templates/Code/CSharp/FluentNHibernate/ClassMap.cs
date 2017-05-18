<%==SIM:ExplicitLinesOn==%>
<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
using FluentNHibernate.Mapping;<%==SIM:Line(2)==%>

namespace <%==SIM:Element.Namespace==%><%==SIM:Line==%>
{<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    public class <%==SIM:Element.Name==%>Map : ClassMap<<%==SIM:Element.Name==%>><%==SIM:Line==%>
    {<%==SIM:Line==%>
        public <%==SIM:Element.Name==%>()<%==SIM:Line==%>
        {<%==SIM:Line==%>
            Table("<%==SIM:Element.Name==%>");<%==SIM:Line==%>
<%==SIM:If:Element.HasPrimaryKey==%>
<%==SIM:If:Equals(Element.PrimaryKeys.Count,1)==%>
<%==SIM:ForEach:Element.PrimaryKeys==%>
            Id(Function(x) x.<%==SIM:Key.Name==%>).GeneratedBy().<%==SIM:If:Key.IsAutoIncrement==%>Native()<%==SIM:EndIf==%><%==SIM:IfNot:Key.IsAutoIncrement==%>Assigned()<%==SIM:EndIf==%>.Column("<%==SIM:Key.Name==%>")<%==SIM:If:Key.HasTypeLength==%>.Length(<%==SIM:Key.TypeLength==%>)<%==SIM:EndIf==%><%==SIM:EndFor==%>;<%==SIM:EndIf==%>
<%==SIM:If:GreaterThan(Element.PrimaryKeys.Count,1)==%>
            CompositeId()<%==SIM:ForEach:Element.PrimaryKeys==%>.KeyProperty(Function(x) x.<%==SIM:Key.Name==%>, "<%==SIM:Key.Name==%>")<%==SIM:EndFor==%>;<%==SIM:EndIf==%>
<%==SIM:EndIf==%><%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.AllAttributes==%><%==SIM:IfNot:Attribute.IsPrimaryKey==%>
            Map(Function(x) x.<%==SIM:Attribute.Name==%>)<%==SIM:If:Attribute.IsNullable==%>.Nullable()<%==SIM:EndIf==%><%==SIM:IfNot:Attribute.IsNullable==%>.Not.Nullable()<%==SIM:EndIf==%>.Column("<%==SIM:Attribute.Name==%>")<%==SIM:If:Attribute.HasTypeLength==%>.Length(<%==SIM:Attribute.TypeLength==%>)<%==SIM:EndIf==%>;
<%==SIM:EndIf==%>
<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.InverseReferences==%>
            HasMany(Function(x) x.<%==SIM:Reference.Name==%>).KeyColumns.Add(<%==SIM:ForEach:Reference.ForeignKeyAttributes==%>"<%==SIM:Attribute.Name==%>"<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>).LazyLoad().Fetch().Subselect().Cascade().SaveUpdate().Inverse();
<%==SIM:Line==%>
<%==SIM:EndFor==%>
            Polymorphism.Explicit();<%==SIM:Line==%>
        }<%==SIM:Line(2)==%>

    }<%==SIM:Line==%>
}<%==SIM:Line==%>
