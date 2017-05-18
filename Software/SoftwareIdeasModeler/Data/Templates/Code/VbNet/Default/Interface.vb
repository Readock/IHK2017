<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Protected==%>
<%==SIM:Set:package=Friend==%>
<%==SIM:Set:public=Public==%>

<%==SIM:ForEach:Imports==%>
    Imports <%==SIM:Import.Name==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>

Namespace <%==SIM:Element.Namespace==%>
<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>
    '<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:Element.Visibility==%> Interface <%==SIM:Element.Name==%>	
    <%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.Operations==%>
	            <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> As <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) <%==SIM:If:Operation.HasReturnType==%>As <%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%>
                <%==SIM:Line==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    End Interface

<%==SIM:EndBlock==%><%==SIM:Line==%>
End Namespace
<%==SIM:Line==%>