<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
<%==SIM:ForEach:Imports==%>
using <%==SIM:Import.Name==%>;
<%==SIM:EndFor==%>

namespace <%==SIM:Diagram.Namespace==%>
{
    public class <%==SIM:Diagram.GetTaggedValue(Context,Context)==%>
    {
        <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%> state = new <%==SIM:Diagram.Elements.FilterByType(initial-state).First.OutRelations.First.To.Name==%>();

    }

}