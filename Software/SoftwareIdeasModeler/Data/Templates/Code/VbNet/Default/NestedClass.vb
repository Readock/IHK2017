<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Protected==%>
<%==SIM:Set:package=Friend==%>
<%==SIM:Set:public=Public==%>


    <%==SIM:ForEach:Element.DocumentationLines==%>
'<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:Element.Visibility==%> <%==SIM:If:Element.IsLeaf==%>NotInheritable <%==SIM:EndIf==%><%==SIM:If:Element.IsAbstract==%>MustInherit <%==SIM:EndIf==%>Class <%==SIM:Element.Name==%>
    <%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:If:Element.HasSuperClass==%>
            Inherits <%==SIM:Element.SuperClass.Name==%>
            <%==SIM:Line==%>
        <%==SIM:EndIf==%>        

        <%==SIM:If:Element.HasInterfaces==%>
            Implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>
            <%==SIM:Line==%>
        <%==SIM:EndIf==%>

        <%==SIM:Line==%>

        <%==SIM:ForEach:Element.NestedClasses==%>
            <%==SIM:Include(NestedClass.vb,NestedClass,False)==%>
        <%==SIM:EndFor==%>

        <%==SIM:ForEach:Element.AllAttributes==%>
                <%==SIM:ForEach:Attribute.DocumentationLines==%>
'<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:If:Equals(Attribute.Visibility,"")==%>Dim<%==SIM:EndIf==%><%==SIM:Attribute.Visibility==%> <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.IsArray==%>()<%==SIM:EndIf==%> As <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
        <%==SIM:EndFor==%>

        <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

        <%==SIM:ForEach:Element.Operations==%>
            <%==SIM:Line==%>
            <%==SIM:ForEach:Operation.DocumentationLines==%>
'<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> Shared<%==SIM:EndIf==%><%==SIM:If:Operation.IsOverride==%> Overrides<%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> Overridable<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> MustOverride<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> As <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) <%==SIM:If:Operation.HasReturnType==%>As <%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%>
            <%==SIM:Line==%>
                <%==SIM:Operation.SourceCodeBody==%>
                <%==SIM:Line==%>
            End <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%>

            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

        <%==SIM:EndFor==%>

        <%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>
    End Class

<%==SIM:Line(3)==%>
