﻿#pragma checksum "C:\Code UDLA\Programacion 4\AgendaPersonal-UWP-dotnet\Hiriart-Corales_UWPApp-AgendaPersonal\Hiriart-Corales_UWPApp-AgendaPersonal\Views\EventosPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2E0B71A5C330C416AE99E698BB3521C7A36A9356E8CC77211DB255EF796044F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Views
{
    partial class EventosPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class EventosPage_obj7_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IEventosPage_Bindings
        {
            private global::Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models.Evento dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj7;
            private global::Windows.UI.Xaml.Controls.TextBlock obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.TextBlock obj13;
            private global::Windows.UI.Xaml.Controls.TextBlock obj14;
            private global::Windows.UI.Xaml.Controls.TextBlock obj15;
            private global::Windows.UI.Xaml.Controls.TextBlock obj16;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj8TextDisabled = false;
            private static bool isobj9TextDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj11TextDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj13TextDisabled = false;
            private static bool isobj14TextDisabled = false;
            private static bool isobj15TextDisabled = false;
            private static bool isobj16TextDisabled = false;

            public EventosPage_obj7_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 59 && columnNumber == 40)
                {
                    isobj8TextDisabled = true;
                }
                else if (lineNumber == 62 && columnNumber == 40)
                {
                    isobj9TextDisabled = true;
                }
                else if (lineNumber == 65 && columnNumber == 40)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 68 && columnNumber == 40)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 71 && columnNumber == 40)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 74 && columnNumber == 40)
                {
                    isobj13TextDisabled = true;
                }
                else if (lineNumber == 77 && columnNumber == 40)
                {
                    isobj14TextDisabled = true;
                }
                else if (lineNumber == 80 && columnNumber == 40)
                {
                    isobj15TextDisabled = true;
                }
                else if (lineNumber == 83 && columnNumber == 40)
                {
                    isobj16TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // Views\EventosPage.xaml line 57
                        this.obj7 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 8: // Views\EventosPage.xaml line 58
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 9: // Views\EventosPage.xaml line 61
                        this.obj9 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 10: // Views\EventosPage.xaml line 64
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 11: // Views\EventosPage.xaml line 67
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 12: // Views\EventosPage.xaml line 70
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // Views\EventosPage.xaml line 73
                        this.obj13 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 14: // Views\EventosPage.xaml line 76
                        this.obj14 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 15: // Views\EventosPage.xaml line 79
                        this.obj15 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 16: // Views\EventosPage.xaml line 82
                        this.obj16 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj7.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models.Evento) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IEventosPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models.Evento)newDataRoot;
                    return true;
                }
                return false;
            }

            private delegate void InvokeFunctionDelegate(int phase);
            private global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate> PendingFunctionBindings = new global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate>();

            private void Invoke_Fecha_M_ToShortDateString_757602046(int phase)
            {
                global::System.String result = this.dataRoot.Fecha.ToShortDateString();
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 58
                    if (!isobj8TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj8, result, null);
                    }
                }
            }

            private void Invoke_Inicio_M_ToShortTimeString_757602046(int phase)
            {
                global::System.String result = this.dataRoot.Inicio.ToShortTimeString();
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 61
                    if (!isobj9TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj9, result, null);
                    }
                }
            }

            private void Invoke_Fin_M_ToShortTimeString_757602046(int phase)
            {
                global::System.String result = this.dataRoot.Fin.ToShortTimeString();
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 64
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, result, null);
                    }
                }
            }

            private void CompleteUpdate(int phase)
            {
                var functions = this.PendingFunctionBindings;
                this.PendingFunctionBindings = new global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate>();
                foreach (var function in functions.Values)
                {
                    function.Invoke(phase);
                }
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models.Evento obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Fecha(obj.Fecha, phase);
                        this.Update_Inicio(obj.Inicio, phase);
                        this.Update_Fin(obj.Fin, phase);
                        this.Update_Titulo(obj.Titulo, phase);
                        this.Update_Descripcion(obj.Descripcion, phase);
                        this.Update_Ubicacion(obj.Ubicacion, phase);
                        this.Update_EsSerie(obj.EsSerie, phase);
                        this.Update_Dias(obj.Dias, phase);
                        this.Update_Contactos(obj.Contactos, phase);
                    }
                }
                this.CompleteUpdate(phase);
            }
            private void Update_Fecha(global::System.DateTime obj, int phase)
            {
                if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                {
                    this.Update_Fecha_M_ToShortDateString_757602046(phase);
                }
            }
            private void Update_Fecha_M_ToShortDateString_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    if (!isobj8TextDisabled)
                    {
                        this.PendingFunctionBindings["Fecha_M_ToShortDateString_757602046"] = new InvokeFunctionDelegate(this.Invoke_Fecha_M_ToShortDateString_757602046); 
                    }
                }
            }
            private void Update_Inicio(global::System.DateTime obj, int phase)
            {
                if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                {
                    this.Update_Inicio_M_ToShortTimeString_757602046(phase);
                }
            }
            private void Update_Inicio_M_ToShortTimeString_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    if (!isobj9TextDisabled)
                    {
                        this.PendingFunctionBindings["Inicio_M_ToShortTimeString_757602046"] = new InvokeFunctionDelegate(this.Invoke_Inicio_M_ToShortTimeString_757602046); 
                    }
                }
            }
            private void Update_Fin(global::System.DateTime obj, int phase)
            {
                if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                {
                    this.Update_Fin_M_ToShortTimeString_757602046(phase);
                }
            }
            private void Update_Fin_M_ToShortTimeString_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    if (!isobj10TextDisabled)
                    {
                        this.PendingFunctionBindings["Fin_M_ToShortTimeString_757602046"] = new InvokeFunctionDelegate(this.Invoke_Fin_M_ToShortTimeString_757602046); 
                    }
                }
            }
            private void Update_Titulo(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 67
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                }
            }
            private void Update_Descripcion(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 70
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                }
            }
            private void Update_Ubicacion(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 73
                    if (!isobj13TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj13, obj, null);
                    }
                }
            }
            private void Update_EsSerie(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 76
                    if (!isobj14TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj14, obj.ToString(), null);
                    }
                }
            }
            private void Update_Dias(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 79
                    if (!isobj15TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj15, obj, null);
                    }
                }
            }
            private void Update_Contactos(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\EventosPage.xaml line 82
                    if (!isobj16TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj16, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\EventosPage.xaml line 10
                {
                    this.ContentArea = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\EventosPage.xaml line 13
                {
                    this.eventoCommandBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 4: // Views\EventosPage.xaml line 31
                {
                    this.EventosList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 17: // Views\EventosPage.xaml line 15
                {
                    this.nuevoBoton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.nuevoBoton).Click += this.NuevoBoton_Click;
                }
                break;
            case 18: // Views\EventosPage.xaml line 17
                {
                    this.editarBoton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.editarBoton).Click += this.EditarBoton_Click;
                }
                break;
            case 19: // Views\EventosPage.xaml line 19
                {
                    this.eliminarBoton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.eliminarBoton).Click += this.EliminarBoton_Click;
                }
                break;
            case 20: // Views\EventosPage.xaml line 23
                {
                    this.ayudaBoton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.ayudaBoton).Click += this.AyudaBoton_Click;
                }
                break;
            case 21: // Views\EventosPage.xaml line 24
                {
                    this.actualizarBoton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.actualizarBoton).Click += this.ActualizarBoton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 7: // Views\EventosPage.xaml line 57
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element7 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    EventosPage_obj7_Bindings bindings = new EventosPage_obj7_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element7.DataContext);
                    element7.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element7, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element7, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

