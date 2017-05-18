<%==SIM:ExplicitLinesOn==%>
<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=public==%>
<%==SIM:Set:public=public==%>
<%==SIM:ForEach:Imports==%>
#include <%==SIM:Import.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
//<%==SIM:DocumentationLine==%>
<%==SIM:Line==%>
<%==SIM:EndFor==%>
class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%> : <%==SIM:ForEach:Element.OutRelations.FilterByType(generalization)==%> <%==SIM:Relation.Visibility==%> <%==SIM:Relation.To.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:Line==%>
{<%==SIM:Line==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(private).Count,0),Equals(Element.Operations.FilterByVisibility(private).Count,0))==%>
    private:<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(private)==%>
        <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Attribute.Type==%> <%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(private)==%>
        <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual <%==SIM:EndIf==%><%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:EndIf==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(protected).Count,0),Equals(Element.Operations.FilterByVisibility(protected).Count,0))==%>
    protected:<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(protected)==%>
        <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Attribute.Type==%> <%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(protected)==%>
        <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual <%==SIM:EndIf==%><%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(internal,public).Count,0),Equals(Element.Operations.FilterByVisibility(internal,public).Count,0))==%>
    public:<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(internal,public)==%>
        <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Attribute.Type==%> <%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(internal,public)==%>
        <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual <%==SIM:EndIf==%><%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Line==%>
<%==SIM:EndIf==%>
};<%==SIM:Line==%>
