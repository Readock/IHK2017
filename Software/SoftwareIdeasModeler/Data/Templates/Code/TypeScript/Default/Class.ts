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
    
<%==SIM:If:Element.IsPublic==%>export <%==SIM:EndIf==%>class <%==SIM:Element.Name==%>
    
<%==SIM:If:Element.HasSuperClass==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%>
<%==SIM:If:Element.HasInterfaces==%> implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>


    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>                        
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Name==%>: <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%>         
        <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
        <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
        
    <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

    <%==SIM:ForEach:Element.Operations==%>
        <%==SIM:If:Operation.IsConstructor==%>
        <%==SIM:Line==%>
        <%==SIM:ForEach:Operation.DocumentationLines==%>        
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        constructor (<%==SIM:ForEach:Operation.Parameters==%> <%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
        <%==SIM:Line==%>
        
        {<%==SIM:StartBlock==%><%==SIM:Line==%>
            <%==SIM:Operation.SourceCodeBody==%>
            
        <%==SIM:EndBlock==%><%==SIM:Line==%>
        }
        <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                        
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.Operations==%>
        <%==SIM:IfNot:Operation.IsConstructor==%>
        <%==SIM:Line==%>
        <%==SIM:ForEach:Operation.DocumentationLines==%>        
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>: <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>): <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%>
        <%==SIM:Line==%>
        
        {<%==SIM:StartBlock==%><%==SIM:Line==%>
            <%==SIM:Operation.SourceCodeBody==%>
            
        <%==SIM:EndBlock==%><%==SIM:Line==%>
        }
        <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                        
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
    
<%==SIM:EndBlock==%><%==SIM:Line==%>
}