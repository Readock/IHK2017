<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
<%==SIM:ForEach:Imports==%>
using <%==SIM:Import.Name==%>;
<%==SIM:EndFor==%>

namespace <%==SIM:Element.Namespace==%>
{
    <%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>public class <%==SIM:Element.Name==%> : <%==SIM:Element.Diagram.GetTaggedValue(BaseState,BaseState)==%>
    {
<%==SIM:ForEach:Element.OutRelations.FilterByType(general-transition)==%>
        public override void <%==SIM:Relation.BehaviorExpression==%>(<%==SIM:Element.Diagram.GetTaggedValue(Context,Context)==%> context)
        {
            context.state = new <%==SIM:Relation.ToElement.Name==%>();
        }
<%==SIM:EndFor==%>
    }
}