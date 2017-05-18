<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Element.Visibility==%><%==SIM:If:Element.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Element.IsLeaf==%> sealed<%==SIM:EndIf==%><%==SIM:If:Element.IsAbstract==%> abstract<%==SIM:EndIf==%> class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClassOrInterface==%> : <%==SIM:Element.SuperClass.Name==%><%==SIM:If:Element.HasInterfaces==%><%==SIM:If:Element.HasSuperClass==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.NestedClasses==%>
        <%==SIM:Include(NestedClass.cs,NestedClass,False)==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>                        
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

        <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Type==%> <%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> 
        <%==SIM:Attribute.Name==%>
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

        <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Operation.IsOverride==%> override<%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> abstract<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.IsAbstract==%>;<%==SIM:EndIf==%>
        <%==SIM:Line==%>

        <%==SIM:IfNot:Operation.IsAbstract==%>                        
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:Operation.SourceCodeBody==%>
            
            <%==SIM:EndBlock==%><%==SIM:Line==%>
            }
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}
<%==SIM:Line(2)==%>