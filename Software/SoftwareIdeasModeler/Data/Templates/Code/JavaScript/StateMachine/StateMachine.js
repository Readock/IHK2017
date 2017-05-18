<%==SIM:ForEach:Diagram.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>

function <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>()
{
<%==SIM:ForEach:Diagram.Elements.FilterByType(general-transition).Select(BehaviorExpression).Distinct==%><%==SIM:IfNot:IsEmpty(Element)==%>
    this.<%==SIM:Element==%> = function(context)
    {
        throw "NotSupported";
    }
<%==SIM:EndIf==%><%==SIM:EndFor==%>
}


<%==SIM:ForEach:Diagram.Elements(Element)==%><%==SIM:If:Element.OfType(state)==%>
<%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>function <%==SIM:Element.Name==%>()
{
<%==SIM:ForEach:Element.OutRelations.FilterByType(general-transition)==%>
    this.<%==SIM:Relation.BehaviorExpression==%> = function(context)
    {
        context.state = new <%==SIM:Relation.ToElement.Name==%>();
    }
<%==SIM:EndFor==%>
}
<%==SIM:Element.Name==%>.prototype = <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>();
<%==SIM:EndIf==%><%==SIM:EndFor==%>
function <%==SIM:Diagram.GetTaggedValue(Context,Context)==%>()
{
    this.state = new <%==SIM:Diagram.Elements.FilterByType(initial-state).First.OutRelations.First.To.Name==%>();
}