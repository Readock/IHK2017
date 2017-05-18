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
<%==SIM:Line==%>

namespace <%==SIM:Element.Namespace==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>
        //<%==SIM:DocumentationLine==%>
        <%==SIM:Line==%>
    <%==SIM:EndFor==%>
    
    <%==SIM:Element.Visibility==%> struct <%==SIM:Element.Name==%><%==SIM:If:Element.HasInterfaces==%> : <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.AllAttributes==%>
                <%==SIM:ForEach:Attribute.DocumentationLines==%>
                    //<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Type==%> <%==SIM:Attribute.Name==%> <%==SIM:If:Attribute.HasDefaultValue==%>= <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
                <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

        <%==SIM:ForEach:Element.Operations==%>
                <%==SIM:ForEach:Operation.DocumentationLines==%>
                    //<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)        
                <%==SIM:Line==%>
                {<%==SIM:Line==%>
                    <%==SIM:Line==%>
                }<%==SIM:Line==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:EndBlock==%><%==SIM:Line==%>
}