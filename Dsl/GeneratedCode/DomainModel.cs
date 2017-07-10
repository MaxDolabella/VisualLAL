﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
namespace Maxsys.VisualLAL
{
	/// <summary>
	/// DomainModel VisualLALDomainModel
	/// Ferramenta para representar graficamente um Léxico Ampliado da Linguagem
	/// </summary>
	[DslDesign::DisplayNameResource("Maxsys.VisualLAL.VisualLALDomainModel.DisplayName", typeof(global::Maxsys.VisualLAL.VisualLALDomainModel), "Maxsys.VisualLAL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Maxsys.VisualLAL.VisualLALDomainModel.Description", typeof(global::Maxsys.VisualLAL.VisualLALDomainModel), "Maxsys.VisualLAL.GeneratedCode.DomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.Diagrams.CoreDesignSurfaceDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("253d7860-58df-4bfe-b270-918282b83122")]
	public partial class VisualLALDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// VisualLALDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0x253d7860, 0x58df, 0x4bfe, 0xb2, 0x70, 0x91, 0x82, 0x82, 0xb8, 0x31, 0x22);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public VisualLALDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
		
	
		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
	
	
		#endregion
		#region Domain model reflection
			
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(LALDominio),
				typeof(Entrada),
				typeof(Simbolo),
				typeof(Sinonimo),
				typeof(SubEntrada),
				typeof(Nocao),
				typeof(Impacto),
				typeof(SimboloTemNocoes),
				typeof(SimboloTemImpactos),
				typeof(SimboloTemSinonimos),
				typeof(DominioTemSimbolos),
				typeof(SimboloReferences),
				typeof(VisualLALDiagram),
				typeof(HyperlinkConnector),
				typeof(SimboloCompartment),
				typeof(global::Maxsys.VisualLAL.FixUpDiagram),
				typeof(global::Maxsys.VisualLAL.ConnectorRolePlayerChanged),
				typeof(global::Maxsys.VisualLAL.CompartmentItemAddRule),
				typeof(global::Maxsys.VisualLAL.CompartmentItemDeleteRule),
				typeof(global::Maxsys.VisualLAL.CompartmentItemRolePlayerChangeRule),
				typeof(global::Maxsys.VisualLAL.CompartmentItemRolePlayerPositionChangeRule),
				typeof(global::Maxsys.VisualLAL.CompartmentItemChangeRule),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(LALDominio), "Nome", LALDominio.NomeDomainPropertyId, typeof(LALDominio.NomePropertyHandler)),
				new DomainMemberInfo(typeof(LALDominio), "Descricao", LALDominio.DescricaoDomainPropertyId, typeof(LALDominio.DescricaoPropertyHandler)),
				new DomainMemberInfo(typeof(Entrada), "Nome", Entrada.NomeDomainPropertyId, typeof(Entrada.NomePropertyHandler)),
				new DomainMemberInfo(typeof(SubEntrada), "Texto", SubEntrada.TextoDomainPropertyId, typeof(SubEntrada.TextoPropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(SimboloTemNocoes), "Simbolo", SimboloTemNocoes.SimboloDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloTemNocoes), "Nocao", SimboloTemNocoes.NocaoDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloTemImpactos), "Simbolo", SimboloTemImpactos.SimboloDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloTemImpactos), "Impacto", SimboloTemImpactos.ImpactoDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloTemSinonimos), "Simbolo", SimboloTemSinonimos.SimboloDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloTemSinonimos), "Sinonimo", SimboloTemSinonimos.SinonimoDomainRoleId),
				new DomainRolePlayerInfo(typeof(DominioTemSimbolos), "LALDominio", DominioTemSimbolos.LALDominioDomainRoleId),
				new DomainRolePlayerInfo(typeof(DominioTemSimbolos), "Simbolo", DominioTemSimbolos.SimboloDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloReferences), "SimboloOrigem", SimboloReferences.SimboloOrigemDomainRoleId),
				new DomainRolePlayerInfo(typeof(SimboloReferences), "SimboloDestino", SimboloReferences.SimboloDestinoDomainRoleId),
			};
		}
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;
	
		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
	
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(10);
				createElementMap.Add(typeof(LALDominio), 0);
				createElementMap.Add(typeof(Simbolo), 1);
				createElementMap.Add(typeof(Sinonimo), 2);
				createElementMap.Add(typeof(Nocao), 3);
				createElementMap.Add(typeof(Impacto), 4);
				createElementMap.Add(typeof(VisualLALDiagram), 5);
				createElementMap.Add(typeof(HyperlinkConnector), 6);
				createElementMap.Add(typeof(SimboloCompartment), 7);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Maxsys.VisualLAL.VisualLALDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new LALDominio(partition, propertyAssignments);
				case 1: return new Simbolo(partition, propertyAssignments);
				case 2: return new Sinonimo(partition, propertyAssignments);
				case 3: return new Nocao(partition, propertyAssignments);
				case 4: return new Impacto(partition, propertyAssignments);
				case 5: return new VisualLALDiagram(partition, propertyAssignments);
				case 6: return new HyperlinkConnector(partition, propertyAssignments);
				case 7: return new SimboloCompartment(partition, propertyAssignments);
				default: return null;
			}
		}
	
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;
	
		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
	
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(5);
				createElementLinkMap.Add(typeof(SimboloTemNocoes), 0);
				createElementLinkMap.Add(typeof(SimboloTemImpactos), 1);
				createElementLinkMap.Add(typeof(SimboloTemSinonimos), 2);
				createElementLinkMap.Add(typeof(DominioTemSimbolos), 3);
				createElementLinkMap.Add(typeof(SimboloReferences), 4);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Maxsys.VisualLAL.VisualLALDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
			
			}
			switch (index)
			{
				case 0: return new SimboloTemNocoes(partition, roleAssignments, propertyAssignments);
				case 1: return new SimboloTemImpactos(partition, roleAssignments, propertyAssignments);
				case 2: return new SimboloTemSinonimos(partition, roleAssignments, propertyAssignments);
				case 3: return new DominioTemSimbolos(partition, roleAssignments, propertyAssignments);
				case 4: return new SimboloReferences(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Maxsys.VisualLAL.GeneratedCode.DomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return VisualLALDomainModel.SingletonResourceManager;
			}
		}
	
		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (VisualLALDomainModel.resourceManager == null)
				{
					VisualLALDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(VisualLALDomainModel).Assembly);
				}
				return VisualLALDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return VisualLALDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return VisualLALDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (VisualLALDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new VisualLALCopyClosure());
					copyFilter.AddFilter(new DslModeling::CoreCopyClosure());
					copyFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceCopyClosure());
					
					VisualLALDomainModel.copyClosure = copyFilter;
				}
				return VisualLALDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (VisualLALDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new VisualLALDeleteClosure());
					removeFilter.AddFilter(new DslModeling::CoreDeleteClosure());
					removeFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceDeleteClosure());
		
					VisualLALDomainModel.removeClosure = removeFilter;
				}
				return VisualLALDomainModel.removeClosure;
			}
		}
		#endregion
		#region Diagram rule helpers
		/// <summary>
		/// Enables rules in this domain model related to diagram fixup for the given store.
		/// If diagram data will be loaded into the store, this method should be called first to ensure
		/// that the diagram behaves properly.
		/// </summary>
		public static void EnableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.FixUpDiagram));
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.ConnectorRolePlayerChanged));
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemAddRule));
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemDeleteRule));
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemRolePlayerChangeRule));
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemRolePlayerPositionChangeRule));
			ruleManager.EnableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemChangeRule));
		}
		
		/// <summary>
		/// Disables rules in this domain model related to diagram fixup for the given store.
		/// </summary>
		public static void DisableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.FixUpDiagram));
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.ConnectorRolePlayerChanged));
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemAddRule));
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemDeleteRule));
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemRolePlayerChangeRule));
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemRolePlayerPositionChangeRule));
			ruleManager.DisableRule(typeof(global::Maxsys.VisualLAL.CompartmentItemChangeRule));
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class VisualLALDeleteClosure : VisualLALDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VisualLALDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class VisualLALDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public VisualLALDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Maxsys.VisualLAL.SimboloTemNocoes.NocaoDomainRoleId, true);
			DomainRoles.Add(global::Maxsys.VisualLAL.SimboloTemImpactos.ImpactoDomainRoleId, true);
			DomainRoles.Add(global::Maxsys.VisualLAL.SimboloTemSinonimos.SinonimoDomainRoleId, true);
			DomainRoles.Add(global::Maxsys.VisualLAL.DominioTemSimbolos.SimboloDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class VisualLALCopyClosure : VisualLALCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VisualLALCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class VisualLALCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VisualLALCopyClosureBase():base()
		{
		}
	}
	#endregion
		
}

