<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package===%>
<%==SIM:Set:public=public==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
    
<%==SIM:If:Element.IsPublic==%>export <%==SIM:EndIf==%>interface <%==SIM:Element.Name==%>
    
<%==SIM:If:Element.HasSuperClassOrInterface==%> extends <%==SIM:ForEach:Union(Element.Interfaces, Element.SuperClasses)==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>


    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>                        
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        <%==SIM:Attribute.Name==%>: <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%>         
        <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
        <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
        
    <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

    <%==SIM:ForEach:Element.Operations==%>
        <%==SIM:Line==%>
        <%==SIM:ForEach:Operation.DocumentationLines==%>        
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>: <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>): <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%>;
        <%==SIM:Line==%>        
                        
    <%==SIM:EndFor==%>
    
<%==SIM:EndBlock==%><%==SIM:Line==%>
}