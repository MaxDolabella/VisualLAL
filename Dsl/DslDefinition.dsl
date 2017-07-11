<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="253d7860-58df-4bfe-b270-918282b83122" Description="Ferramenta para representar graficamente um Léxico Ampliado da Linguagem" Name="VisualLAL" DisplayName="VisualLAL" Namespace="Maxsys.VisualLAL" Build="1" ProductName="VisualLAL" CompanyName="Maxsys" PackageGuid="92b8be84-5876-454a-a110-d7663866aacd" PackageNamespace="Maxsys.VisualLAL" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="731968b2-470a-405d-9f66-e7b0db7cd416" Description="É o objeto que contém todos os Símbolos" Name="LALDominio" DisplayName="LALDominio" Namespace="Maxsys.VisualLAL">
      <Properties>
        <DomainProperty Id="e3218d11-375d-446e-ad1b-9c97bde094c5" Description="Nome do Domínio" Name="Nome" DisplayName="Nome" DefaultValue="Domínio1">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="6823ac45-166e-47b9-9f98-4e6389ada820" Description="Descrição do Domínio" Name="Descricao" DisplayName="Descrição">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(System.ComponentModel.Design.MultilineStringEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Simbolo" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DominioTemSimbolos.Simbolos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="89b49b9b-0d4a-4805-a5ed-525489297abf" Description="Representa uma entrada no LAL. Pode ser um Símbolo ou um Sinônimo de um Símbolo." Name="Entrada" DisplayName="Entrada" InheritanceModifier="Abstract" Namespace="Maxsys.VisualLAL">
      <Notes>Cada Entrada deve ser única. Não podem haver duas ou mais Entradas com a mesma propriedade nome.</Notes>
      <Properties>
        <DomainProperty Id="f9568314-2ba8-4682-8954-dc1fd31e9c13" Description="Nome da entrada (Símbolo ou Sinônimo)." Name="Nome" DisplayName="Nome" IsElementName="true">
          <Notes>Nome deve ser único no LAL.</Notes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="c607dae6-2730-445b-8fd9-b0015866b839" Description="Representa uma entrada única no LAL" Name="Simbolo" DisplayName="Símbolo" Namespace="Maxsys.VisualLAL">
      <BaseClass>
        <DomainClassMoniker Name="Entrada" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="df99a777-1a1b-4822-a409-f488b333a3e8" Description="A tipo do símbolo." Name="Tipo" DisplayName="Tipo do Símbolo">
          <Type>
            <DomainEnumerationMoniker Name="TipoSimbolo" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Nocao" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SimboloTemNocoes.Nocoes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Impacto" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SimboloTemImpactos.Impactos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Sinonimo" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>SimboloTemSinonimos.Sinonimos</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="9127e53e-6b80-465d-bd5d-a9e1d56ef0af" Description="Representa uma entrada única no LAL, sendo sinônimo de um símbolo." Name="Sinonimo" DisplayName="Sinônimo" Namespace="Maxsys.VisualLAL">
      <BaseClass>
        <DomainClassMoniker Name="Entrada" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="5381e9e9-a48d-4682-849a-113bf8a98bbc" Description="Representa uma Noção ou um Impacto do Símbolo" Name="SubEntrada" DisplayName="SubEntrada" InheritanceModifier="Abstract" Namespace="Maxsys.VisualLAL">
      <Properties>
        <DomainProperty Id="b6e929b1-3aec-484c-a2c2-14c65e02983b" Description="Texto da Noção/Impacto" Name="Texto" DisplayName="Texto" DefaultValue="Texto_Aqui">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.Editor">
              <Parameters>
                <AttributeParameter Value="typeof(System.ComponentModel.Design.MultilineStringEditor)" />
                <AttributeParameter Value="typeof(System.Drawing.Design.UITypeEditor)" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="3af5d015-0ebf-4230-8f7f-ebbfca1510b2" Description="É o signficado do Símbolo (denotação)." Name="Nocao" DisplayName="Noção" Namespace="Maxsys.VisualLAL">
      <Notes>A noção é o seu significado relativo ao domínio.</Notes>
      <BaseClass>
        <DomainClassMoniker Name="SubEntrada" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="d6e67379-0eff-4567-9c05-7b78140f47bc" Description="Efeitos do uso/ocorrência do símbolo na aplicação ou do efeito de algo na aplicação sobre esse símbolo (conotação)." Name="Impacto" DisplayName="Impacto" Namespace="Maxsys.VisualLAL">
      <Notes>Caracterizam restrições impostas pelo/ao símbolo.</Notes>
      <BaseClass>
        <DomainClassMoniker Name="SubEntrada" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="94e5eeac-029c-4eda-a3e9-31acd980eac8" Description="Cada símbolo tem uma ou mais noções." Name="SimboloTemNocoes" DisplayName="Simbolo Tem Noções" Namespace="Maxsys.VisualLAL" IsEmbedding="true">
      <Source>
        <DomainRole Id="55eafc5a-bac3-4cda-9c60-7bf4aa51df4d" Description="Noções que o símbolo possui" Name="Simbolo" DisplayName="Símbolo" PropertyName="Nocoes" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Noções">
          <RolePlayer>
            <DomainClassMoniker Name="Simbolo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="7f268a76-fefa-49bb-b031-a409f81a949b" Description="Símbolo ao qual pertence a noção." Name="Nocao" DisplayName="Noção" PropertyName="Simbolo" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Símbolo">
          <RolePlayer>
            <DomainClassMoniker Name="Nocao" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="24236bf4-9b93-44f3-b5ea-bb350cae46c5" Description="Cada símbolo tem um ou mais Impactos." Name="SimboloTemImpactos" DisplayName="Simbolo Tem Impactos" Namespace="Maxsys.VisualLAL" IsEmbedding="true">
      <Source>
        <DomainRole Id="4edd7133-a8c2-4d1e-b7ea-80ecd32c9651" Description="Impactos que o símbolo possui." Name="Simbolo" DisplayName="Símbolo" PropertyName="Impactos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Impactos">
          <RolePlayer>
            <DomainClassMoniker Name="Simbolo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="68d34e5a-8f19-4b25-afd9-f24e9f9517c1" Description="Símbolo ao qual pertence o impacto." Name="Impacto" DisplayName="Impacto" PropertyName="Simbolo" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Símbolo">
          <RolePlayer>
            <DomainClassMoniker Name="Impacto" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="0a7e7d37-d2b8-4574-81c8-1ee14af2d7cc" Description="Cada símbolo pode ter nenhum ou muitos Sinônimos" Name="SimboloTemSinonimos" DisplayName="Simbolo Tem Sinônimos" Namespace="Maxsys.VisualLAL" IsEmbedding="true">
      <Source>
        <DomainRole Id="4e51e05f-b640-49fa-9e99-136ba66ac4fe" Description="Sinônimos que o símbolo possui." Name="Simbolo" DisplayName="Símbolo" PropertyName="Sinonimos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Sinonimos">
          <RolePlayer>
            <DomainClassMoniker Name="Simbolo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="904fd952-e0fb-40b1-88d4-faa801375bd2" Description="Símbolo ao qual pertence o sinônimo." Name="Sinonimo" DisplayName="Sinônimo" PropertyName="Simbolo" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Símbolo">
          <RolePlayer>
            <DomainClassMoniker Name="Sinonimo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="0f303d11-c6aa-4da7-bd62-6e3dfacc9cba" Description="Description for Maxsys.VisualLAL.DominioTemSimbolos" Name="DominioTemSimbolos" DisplayName="Dominio Tem Simbolos" Namespace="Maxsys.VisualLAL" IsEmbedding="true">
      <Source>
        <DomainRole Id="581eafb7-5862-42a9-bc86-039097c37d52" Description="Description for Maxsys.VisualLAL.DominioTemSimbolos.LALDominio" Name="LALDominio" DisplayName="LALDominio" PropertyName="Simbolos" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Simbolos">
          <RolePlayer>
            <DomainClassMoniker Name="LALDominio" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="00292fe2-1a1f-4b66-8a64-90bc514ee329" Description="Description for Maxsys.VisualLAL.DominioTemSimbolos.Simbolo" Name="Simbolo" DisplayName="Simbolo" PropertyName="Dominio" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Dominio">
          <RolePlayer>
            <DomainClassMoniker Name="Simbolo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="5167fe0f-7784-48e4-87a4-d3601b695444" Description="Cada Símbolo está ligado a outro atravês de hyperlinks; Esses hyperlinks estão nas Noções e/ou Impactos." Name="SimboloReferences" DisplayName="Simbolo References" Namespace="Maxsys.VisualLAL">
      <Source>
        <DomainRole Id="9ab9aedd-fad6-466d-86a1-981f3f0c6591" Description="Símbolos mencionados neste Símbolo." Name="SimboloOrigem" DisplayName="Símbolo de origem" PropertyName="ReferenciaSimbolos" PropertyDisplayName="Referencia Simbolos">
          <RolePlayer>
            <DomainClassMoniker Name="Simbolo" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9f6ad877-1d8c-4662-9de7-c0f105bd91c6" Description="Símbolos que mencionam este Símbolo" Name="SimboloDestino" DisplayName="Simbolo de Destino" PropertyName="EhRefenciadoPorSimbolos" PropertyDisplayName="É Refenciado Por Simbolos">
          <RolePlayer>
            <DomainClassMoniker Name="Simbolo" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <ExternalType Name="Color" Namespace="System.Drawing" />
    <DomainEnumeration Name="TipoSimbolo" Namespace="Maxsys.VisualLAL" Description="Description for Maxsys.VisualLAL.TipoSimbolo">
      <Literals>
        <EnumerationLiteral Description="Símbolo ainda não classificado." Name="NãoClassificado" Value="0">
          <Notes>O símbolo precisa ser classificado em Sujeito, Verbo, Objeto ou Estado</Notes>
        </EnumerationLiteral>
        <EnumerationLiteral Description="Indica que o símbolo é um sujeito." Name="Sujeito" Value="1">
          <Notes>Noção: Quem é o sujeito. 
Impacto: Quais ações executa.</Notes>
        </EnumerationLiteral>
        <EnumerationLiteral Description="Description for Maxsys.VisualLAL.TipoSimbolo.Verbo" Name="Verbo" Value="2">
          <Notes>Noção: Quem realiza, quando acontece e quais os procedimentos envolvidos.
Impacto: Quais os reflexos da ação no ambiente (outras ações que devem ocorrer) e quais os novos estados decorrentes.</Notes>
        </EnumerationLiteral>
        <EnumerationLiteral Description="Description for Maxsys.VisualLAL.TipoSimbolo.Objeto" Name="Objeto" Value="3">
          <Notes>Noção: Definir o objeto e identificar outros objetos com os quais se relaciona.
Impacto: Ações que podem ser aplicadas ao objeto.</Notes>
        </EnumerationLiteral>
        <EnumerationLiteral Description="Description for Maxsys.VisualLAL.TipoSimbolo.Estado" Name="Estado" Value="4">
          <Notes>Noção: O que significa e quais ações levaram a esse estado.
Impacto: Identificar outros estados e ações que podem ocorrer a partir do estado que se descreve.</Notes>
        </EnumerationLiteral>
      </Literals>
    </DomainEnumeration>
  </Types>
  <Shapes>
    <CompartmentShape Id="047c248e-a76e-48d9-8ad9-2b5e2df2be30" Description="Representação gráfica de um Símbolo" Name="SimboloCompartment" DisplayName="Compartmento de Símbolo" Namespace="Maxsys.VisualLAL" FixedTooltipText="Compartmento de Símbolo" FillColor="WhiteSmoke" InitialWidth="2" InitialHeight="0.3" OutlineThickness="0" FillGradientMode="ForwardDiagonal" Geometry="RoundedRectangle">
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NomeTextDecorator" DisplayName="Nome Text Decorator" DefaultText="NomeTextDecorator" FontStyle="Bold, Italic" FontSize="10" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapseDecorator" DisplayName="Expandir/Recolher" />
      </ShapeHasDecorators>
      <Compartment Name="NocaoCompartment" EntryFontStyle="Italic" EntryFontSize="9" Title="Noção:" />
      <Compartment Name="ImpactoCompartment" EntryFontStyle="Italic" EntryFontSize="9" Title="Impacto:" />
      <Compartment Name="SinonimoCompartment" EntryFontStyle="Italic" EntryFontSize="9" Title="Sinônimo:" />
    </CompartmentShape>
  </Shapes>
  <Connectors>
    <Connector Id="a0900da9-7a9b-4f5e-9e66-b72c3b14019c" Description="Representa existência de pelo menos 1 hyperlink entre os Símbolos conectados." Name="HyperlinkConnector" DisplayName="Hyperlink" Namespace="Maxsys.VisualLAL" FixedTooltipText="Hyperlink" Color="Silver" Thickness="0.02" />
  </Connectors>
  <XmlSerializationBehavior Name="VisualLALSerializationBehavior" Namespace="Maxsys.VisualLAL">
    <ClassData>
      <XmlClassData TypeName="LALDominio" MonikerAttributeName="" SerializeId="true" MonikerElementName="lALDominioMoniker" ElementName="lALDominio" MonikerTypeName="LALDominioMoniker">
        <DomainClassMoniker Name="LALDominio" />
        <ElementData>
          <XmlPropertyData XmlName="nome">
            <DomainPropertyMoniker Name="LALDominio/Nome" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="descricao">
            <DomainPropertyMoniker Name="LALDominio/Descricao" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="simbolos">
            <DomainRelationshipMoniker Name="DominioTemSimbolos" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="HyperlinkConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="hyperlinkConnectorMoniker" ElementName="hyperlinkConnector" MonikerTypeName="HyperlinkConnectorMoniker">
        <ConnectorMoniker Name="HyperlinkConnector" />
      </XmlClassData>
      <XmlClassData TypeName="VisualLALDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="visualLALDiagramMoniker" ElementName="visualLALDiagram" MonikerTypeName="VisualLALDiagramMoniker">
        <DiagramMoniker Name="VisualLALDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Entrada" MonikerAttributeName="nome" SerializeId="true" MonikerElementName="entradaMoniker" ElementName="entrada" MonikerTypeName="EntradaMoniker">
        <DomainClassMoniker Name="Entrada" />
        <ElementData>
          <XmlPropertyData XmlName="nome" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Entrada/Nome" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Simbolo" MonikerAttributeName="" SerializeId="true" MonikerElementName="simboloMoniker" ElementName="simbolo" MonikerTypeName="SimboloMoniker">
        <DomainClassMoniker Name="Simbolo" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="nocoes">
            <DomainRelationshipMoniker Name="SimboloTemNocoes" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="impactos">
            <DomainRelationshipMoniker Name="SimboloTemImpactos" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="sinonimos">
            <DomainRelationshipMoniker Name="SimboloTemSinonimos" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="referenciaSimbolos">
            <DomainRelationshipMoniker Name="SimboloReferences" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="tipo">
            <DomainPropertyMoniker Name="Simbolo/Tipo" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Sinonimo" MonikerAttributeName="" SerializeId="true" MonikerElementName="sinonimoMoniker" ElementName="sinonimo" MonikerTypeName="SinonimoMoniker">
        <DomainClassMoniker Name="Sinonimo" />
      </XmlClassData>
      <XmlClassData TypeName="SubEntrada" MonikerAttributeName="" SerializeId="true" MonikerElementName="subEntradaMoniker" ElementName="subEntrada" MonikerTypeName="SubEntradaMoniker">
        <DomainClassMoniker Name="SubEntrada" />
        <ElementData>
          <XmlPropertyData XmlName="texto">
            <DomainPropertyMoniker Name="SubEntrada/Texto" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Nocao" MonikerAttributeName="" SerializeId="true" MonikerElementName="nocaoMoniker" ElementName="nocao" MonikerTypeName="NocaoMoniker">
        <DomainClassMoniker Name="Nocao" />
      </XmlClassData>
      <XmlClassData TypeName="Impacto" MonikerAttributeName="" SerializeId="true" MonikerElementName="impactoMoniker" ElementName="impacto" MonikerTypeName="ImpactoMoniker">
        <DomainClassMoniker Name="Impacto" />
      </XmlClassData>
      <XmlClassData TypeName="SimboloTemNocoes" MonikerAttributeName="" SerializeId="true" MonikerElementName="simboloTemNocoesMoniker" ElementName="simboloTemNocoes" MonikerTypeName="SimboloTemNocoesMoniker">
        <DomainRelationshipMoniker Name="SimboloTemNocoes" />
      </XmlClassData>
      <XmlClassData TypeName="SimboloTemImpactos" MonikerAttributeName="" SerializeId="true" MonikerElementName="simboloTemImpactosMoniker" ElementName="simboloTemImpactos" MonikerTypeName="SimboloTemImpactosMoniker">
        <DomainRelationshipMoniker Name="SimboloTemImpactos" />
      </XmlClassData>
      <XmlClassData TypeName="SimboloTemSinonimos" MonikerAttributeName="" SerializeId="true" MonikerElementName="simboloTemSinonimosMoniker" ElementName="simboloTemSinonimos" MonikerTypeName="SimboloTemSinonimosMoniker">
        <DomainRelationshipMoniker Name="SimboloTemSinonimos" />
      </XmlClassData>
      <XmlClassData TypeName="DominioTemSimbolos" MonikerAttributeName="" SerializeId="true" MonikerElementName="dominioTemSimbolosMoniker" ElementName="dominioTemSimbolos" MonikerTypeName="DominioTemSimbolosMoniker">
        <DomainRelationshipMoniker Name="DominioTemSimbolos" />
      </XmlClassData>
      <XmlClassData TypeName="SimboloReferences" MonikerAttributeName="" SerializeId="true" MonikerElementName="simboloReferencesMoniker" ElementName="simboloReferences" MonikerTypeName="SimboloReferencesMoniker">
        <DomainRelationshipMoniker Name="SimboloReferences" />
      </XmlClassData>
      <XmlClassData TypeName="SimboloCompartment" MonikerAttributeName="" SerializeId="true" MonikerElementName="simboloCompartmentMoniker" ElementName="simboloCompartment" MonikerTypeName="SimboloCompartmentMoniker">
        <CompartmentShapeMoniker Name="SimboloCompartment" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="VisualLALExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="SimboloReferencesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="SimboloReferences" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Simbolo" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Simbolo" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="4d9461df-e2b9-4133-b184-7f598d7b68ab" Description="Representa graficamento o Léxico Ampliado da Linguagem para um determinado domínio" Name="VisualLALDiagram" DisplayName="Diagrama do Léxico Ampliado da Linguagem" Namespace="Maxsys.VisualLAL" FillColor="Window">
    <Class>
      <DomainClassMoniker Name="LALDominio" />
    </Class>
    <ShapeMaps>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="Simbolo" />
        <ParentElementPath>
          <DomainPath>DominioTemSimbolos.Dominio/!LALDominio</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="SimboloCompartment/NomeTextDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Entrada/Nome" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="SimboloCompartment" />
        <CompartmentMap>
          <CompartmentMoniker Name="SimboloCompartment/ImpactoCompartment" />
          <ElementsDisplayed>
            <DomainPath>SimboloTemImpactos.Impactos/!Impacto</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="SubEntrada/Texto" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="SimboloCompartment/NocaoCompartment" />
          <ElementsDisplayed>
            <DomainPath>SimboloTemNocoes.Nocoes/!Nocao</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="SubEntrada/Texto" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="SimboloCompartment/SinonimoCompartment" />
          <ElementsDisplayed>
            <DomainPath>SimboloTemSinonimos.Sinonimos/!Sinonimo</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Entrada/Nome" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="HyperlinkConnector" />
        <DomainRelationshipMoniker Name="SimboloReferences" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="vlal" EditorGuid="54f7a544-5de7-4c80-9687-6bbfdcd6251f">
    <RootClass>
      <DomainClassMoniker Name="LALDominio" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="true">
      <XmlSerializationBehaviorMoniker Name="VisualLALSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="VisualLAL">
      <ElementTool Name="Simbolo" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Símbolo" Tooltip="Representa uma entrada única no LAL" HelpKeyword="Simbolo">
        <DomainClassMoniker Name="Simbolo" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="true" UsesOpen="true" UsesSave="true" UsesLoad="true" />
    <DiagramMoniker Name="VisualLALDiagram" />
  </Designer>
  <Explorer ExplorerGuid="3c234f57-6ad8-4db1-8b0c-07ae6f348283" Title="VisualLAL Explorer">
    <ExplorerBehaviorMoniker Name="VisualLAL/VisualLALExplorer" />
  </Explorer>
</Dsl>