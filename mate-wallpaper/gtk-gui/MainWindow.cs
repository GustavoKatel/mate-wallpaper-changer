
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action newAction;
	private global::Gtk.Action FileAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.ScrolledWindow scrollBox;
	private global::Gtk.HBox m_hb_services;
	private global::Gtk.HBox vbox2;
	private global::Gtk.ScrolledWindow m_hb_config;
	private global::Gtk.HBox hbox2;
	private global::Gtk.Button button1;
	private global::Gtk.Button m_btSave;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.newAction = new global::Gtk.Action ("newAction", null, null, "gtk-new");
		w1.Add (this.newAction, null);
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MatePaper");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		this.AllowShrink = true;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.scrollBox = new global::Gtk.ScrolledWindow ();
		this.scrollBox.CanFocus = true;
		this.scrollBox.Name = "scrollBox";
		this.scrollBox.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrollBox.Gtk.Container+ContainerChild
		global::Gtk.Viewport w2 = new global::Gtk.Viewport ();
		w2.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport.Gtk.Container+ContainerChild
		this.m_hb_services = new global::Gtk.HBox ();
		this.m_hb_services.Name = "m_hb_services";
		this.m_hb_services.Spacing = 6;
		w2.Add (this.m_hb_services);
		this.scrollBox.Add (w2);
		this.vbox1.Add (this.scrollBox);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.scrollBox]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.HBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.m_hb_config = new global::Gtk.ScrolledWindow ();
		this.m_hb_config.CanFocus = true;
		this.m_hb_config.Name = "m_hb_config";
		this.m_hb_config.ShadowType = ((global::Gtk.ShadowType)(1));
		this.vbox2.Add (this.m_hb_config);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.m_hb_config]));
		w6.Position = 0;
		this.vbox1.Add (this.vbox2);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox2]));
		w7.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseStock = true;
		this.button1.UseUnderline = true;
		this.button1.Label = "gtk-quit";
		this.hbox2.Add (this.button1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.button1]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.m_btSave = new global::Gtk.Button ();
		this.m_btSave.CanFocus = true;
		this.m_btSave.Name = "m_btSave";
		this.m_btSave.UseStock = true;
		this.m_btSave.UseUnderline = true;
		this.m_btSave.Label = "gtk-save";
		this.hbox2.Add (this.m_btSave);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.m_btSave]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		this.vbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
		w10.Position = 2;
		w10.Expand = false;
		w10.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 572;
		this.DefaultHeight = 450;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.button1.Clicked += new global::System.EventHandler (this.onExitClicked);
		this.m_btSave.Clicked += new global::System.EventHandler (this.onSaveClicked);
	}
}
