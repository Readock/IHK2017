<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:IfNot:Element.IsContained==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package= ==%><%==SIM:Set:public=public==%>

package <%==SIM:Element.Namespace==%>;
<%==SIM:Line==%>


<%==SIM:ForEach:Imports==%>
	import <%==SIM:Import.Name==%>;
	<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:ForEach:Element.TaggedValues("Import")==%>
	import <%==SIM:TaggedValue.Value==%>;
	<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Element.Visibility==%> class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%><%==SIM:If:Element.HasInterfaces==%> implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.NestedClasses==%>
        <%==SIM:Include(NestedClass.java,NestedClass,False)==%>
    <%==SIM:EndFor==%>

	<%==SIM:ForEach:Element.AllAttributes==%>
		<%==SIM:ForEach:Attribute.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		<%==SIM:Attribute.Visibility==%> <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
		<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
	<%==SIM:EndFor==%>

	<%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

	<%==SIM:ForEach:Element.Operations==%>
		<%==SIM:Line==%>
		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:Operation.Visibility==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) 
		<%==SIM:Line==%>
		{<%==SIM:StartBlock==%><%==SIM:Line==%>
			<%==SIM:Operation.SourceCodeBody==%>
		<%==SIM:EndBlock==%><%==SIM:Line==%>
        }
		<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

	<%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>

<%==SIM:EndIf==%>
