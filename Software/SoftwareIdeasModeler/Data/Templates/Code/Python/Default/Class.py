<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:Set:private=__==%><%==SIM:Set:protected===%><%==SIM:Set:package===%><%==SIM:Set:public===%>

<%==SIM:ForEach:Element.DocumentationLines==%>#<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%>(<%==SIM:ForEach:Element.SuperClasses==%><%==SIM:SuperClass.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:EndIf==%>:
<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes==%><%==SIM:If:Attribute.IsStatic==%>    
	
	<%==SIM:ForEach:Attribute.DocumentationLines==%>
	#<%==SIM:DocumentationLine==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>
	
	<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%><%==SIM:IfNot:Attribute.HasDefaultValue==%>0<%==SIM:EndIf==%>
	<%==SIM:Line==%>

    assert(type(<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%>)==<%==SIM:Attribute.Type==%>)
	<%==SIM:Line(2)==%>
<%==SIM:EndIf==%><%==SIM:EndFor==%>

	def __init__(self):	
	<%==SIM:StartBlock==%><%==SIM:Line==%>

	<%==SIM:ForEach:Element.AllAttributes==%><%==SIM:IfNot:Attribute.IsStatic==%>
			<%==SIM:ForEach:Attribute.DocumentationLines==%>
			#<%==SIM:DocumentationLine==%><%==SIM:Line==%>	
			<%==SIM:EndFor==%>

			self.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%><%==SIM:IfNot:Attribute.HasDefaultValue==%>0<%==SIM:EndIf==%>    
			<%==SIM:Line==%>
	<%==SIM:EndIf==%><%==SIM:EndFor==%>
	<%==SIM:EndBlock==%>
	<%==SIM:Line==%>

	<%==SIM:ForEach:Element.Operations==%>    
	<%==SIM:ForEach:Operation.DocumentationLines==%>#<%==SIM:DocumentationLine==%><%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
	def <%==SIM:Operation.Visibility==%><%==SIM:Operation.Name==%> (self<%==SIM:ForEach:Operation.Parameters==%>, <%==SIM:Parameter.Name==%><%==SIM:EndFor==%>):	
	<%==SIM:StartBlock==%><%==SIM:Line==%>
        # implementation<%==SIM:Line==%>
		<%==SIM:Operation.SourceCodeBody==%>
		<%==SIM:Line==%>
	<%==SIM:EndBlock==%>

<%==SIM:EndFor==%>
<%==SIM:EndBlock==%>
