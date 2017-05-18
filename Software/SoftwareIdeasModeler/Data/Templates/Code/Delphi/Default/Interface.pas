<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package===%>
<%==SIM:Set:public=public==%>

unit <%==SIM:Element.Name==%>Unit;
<%==SIM:Line(2)==%>

interface
<%==SIM:Line(2)==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:If:HasImports==%>
uses
<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Imports==%>
		<%==SIM:Import.Name==%>
		<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>		
	<%==SIM:EndFor==%>;
	<%==SIM:EndBlock==%><%==SIM:Line==%>
<%==SIM:Line==%>

<%==SIM:EndIf==%>

type
<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:Element.Name==%> = Interface(IInterface)
	<%==SIM:StartBlock==%><%==SIM:Line(2)==%>

    <%==SIM:ForEach:Element.Operations==%>
		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
	<%==SIM:IfNot:Operation.HasReturnType==%>
		<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>procedure  <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>);
		<%==SIM:If:Operation.IsVirtual==%> virtual;<%==SIM:EndIf==%>
		<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
		<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
	<%==SIM:EndIf==%>

    <%==SIM:If:Operation.HasReturnType==%>
		<%==SIM:If:Operation.IsStatic==%>class <%==SIM:EndIf==%>function <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>; <%==SIM:EndIf==%><%==SIM:EndFor==%>) : <%==SIM:Operation.ReturnType==%>;
		<%==SIM:If:Operation.IsVirtual==%> virtual;<%==SIM:EndIf==%>
		<%==SIM:If:Operation.IsAbstract==%> abstract;<%==SIM:EndIf==%>
		<%==SIM:If:Operation.IsOverloaded==%> overload;<%==SIM:EndIf==%>
	<%==SIM:EndIf==%>

	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
end;

<%==SIM:EndBlock==%><%==SIM:Line==%>
end.
<%==SIM:Line==%>