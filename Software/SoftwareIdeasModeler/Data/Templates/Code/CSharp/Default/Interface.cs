<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=internal==%><%==SIM:Set:public=public==%>

<%==SIM:ForEach:Imports==%>
    using <%==SIM:Import.Name==%>;
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

namespace <%==SIM:Element.Namespace==%><%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>
        //<%==SIM:DocumentationLine==%>
        <%==SIM:Line==%>
    <%==SIM:EndFor==%>
    
    <%==SIM:Element.Visibility==%> interface <%==SIM:Element.Name==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.Operations==%>
            <%==SIM:ForEach:Operation.DocumentationLines==%>
                //<%==SIM:DocumentationLine==%>
                <%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);            

            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

    <%==SIM:EndBlock==%><%==SIM:Line==%>
}