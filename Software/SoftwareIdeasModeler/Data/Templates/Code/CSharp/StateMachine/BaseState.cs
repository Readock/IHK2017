<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
<%==SIM:ForEach:Imports==%>
using <%==SIM:Import.Name==%>;
<%==SIM:EndFor==%>

namespace <%==SIM:Diagram.Namespace==%>
{
    public abstract class <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>
    {
<%==SIM:ForEach:Diagram.Elements.FilterByType(general-transition).Select(BehaviorExpression).Distinct==%><%==SIM:IfNot:IsEmpty(Element)==%>
        public virtual void <%==SIM:Element==%>(<%==SIM:Diagram.GetTaggedValue(Context,Context)==%> context)
        {
            throw new NotSupportedException();
        }
<%==SIM:EndIf==%><%==SIM:EndFor==%>
    }

}