<%==SIM:ExplicitLinesOn==%>
<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Protected==%>
<%==SIM:Set:package=Friend==%>
<%==SIM:Set:public=Public==%>
Imports FluentNHibernate.Mapping<%==SIM:Line(2)==%>

Namespace <%==SIM:Element.Namespace==%><%==SIM:Line(2)==%>
<%==SIM:ForEach:Element.DocumentationLines==%>'<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    Public Class <%==SIM:Element.Name==%>Map<%==SIM:Line==%>
        Inherits ClassMap(Of <%==SIM:Element.Name==%>)<%==SIM:Line(2)==%>

        Public Sub New()<%==SIM:Line(2)==%>

            Table("<%==SIM:Element.Name==%>")<%==SIM:Line==%>
<%==SIM:If:Element.HasPrimaryKey==%>
<%==SIM:If:Equals(Element.PrimaryKeys.Count,1)==%>
<%==SIM:ForEach:Element.PrimaryKeys==%>
            Id(Function(x) x.<%==SIM:Key.Name==%>).GeneratedBy().<%==SIM:If:Key.IsAutoIncrement==%>Native()<%==SIM:EndIf==%><%==SIM:IfNot:Key.IsAutoIncrement==%>Assigned()<%==SIM:EndIf==%>.Column("<%==SIM:Key.Name==%>")<%==SIM:If:Key.HasTypeLength==%>.Length(<%==SIM:Key.TypeLength==%>)<%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
<%==SIM:If:GreaterThan(Element.PrimaryKeys.Count,1)==%>
            CompositeId()<%==SIM:ForEach:Element.PrimaryKeys==%>.KeyProperty(Function(x) x.<%==SIM:Key.Name==%>, "<%==SIM:Key.Name==%>")<%==SIM:EndFor==%><%==SIM:EndIf==%>
<%==SIM:EndIf==%><%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.AllAttributes==%><%==SIM:IfNot:Attribute.IsPrimaryKey==%>
            Map(Function(x) x.<%==SIM:Attribute.Name==%>)<%==SIM:If:Attribute.IsNullable==%>.Nullable()<%==SIM:EndIf==%><%==SIM:IfNot:Attribute.IsNullable==%>.Not.Nullable()<%==SIM:EndIf==%>.Column("<%==SIM:Attribute.Name==%>")<%==SIM:If:Attribute.HasTypeLength==%>.Length(<%==SIM:Attribute.TypeLength==%>)<%==SIM:EndIf==%>
<%==SIM:EndIf==%>
<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.InverseReferences==%>
            HasMany(Function(x) x.<%==SIM:Reference.Name==%>).KeyColumns.Add(<%==SIM:ForEach:Reference.ForeignKeyAttributes==%>"<%==SIM:Attribute.Name==%>"<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>).LazyLoad().Fetch().Subselect().Cascade().SaveUpdate().Inverse() 
<%==SIM:Line==%>
<%==SIM:EndFor==%>
            Polymorphism.Explicit()<%==SIM:Line==%>
        End Sub<%==SIM:Line(2)==%>

    End Class<%==SIM:Line==%>
End Namespace<%==SIM:Line==%>
