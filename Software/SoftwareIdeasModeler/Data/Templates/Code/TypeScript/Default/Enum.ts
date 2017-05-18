<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
    
<%==SIM:If:Element.IsPublic==%>export <%==SIM:EndIf==%>enum <%==SIM:Element.Name==%>
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

