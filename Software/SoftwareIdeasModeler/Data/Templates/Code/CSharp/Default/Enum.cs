<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>

<%==SIM:ForEach:Imports==%>
    using <%==SIM:Import.Name==%>;
    <%==SIM:Line==%>
<%==SIM:EndFor==%>

namespace <%==SIM:Element.Namespace==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>
        //<%==SIM:DocumentationLine==%>
        <%==SIM:Line==%>
    <%==SIM:EndFor==%>
    
    <%==SIM:Element.Visibility==%> enum <%==SIM:Element.Name==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.Attributes==%>
            <%==SIM:ForEach:Attribute.DocumentationLines==%>
                //<%==SIM:DocumentationLine==%>
                <%==SIM:Line==%>
            <%==SIM:EndFor==%>
    
            <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
            <%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:EndBlock==%><%==SIM:Line==%>
}