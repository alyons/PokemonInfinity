import java.awt.*;
import java.awt.event.*;
import java.awt.EventQueue;

import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JSplitPane;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.AbstractListModel;

public class MainWindow implements ActionListener {

	private JFrame frame;
	JFileChooser fileChooser;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainWindow window = new MainWindow();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public MainWindow() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 640, 480);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JMenuBar menuBar = new JMenuBar();
		frame.setJMenuBar(menuBar);
		
		JMenu mnFile = new JMenu("File");
		menuBar.add(mnFile);
		
		JMenuItem mntmNew = new JMenuItem("New");
		mnFile.add(mntmNew);
		
		JMenuItem mntmOpen = new JMenuItem("Open");
		mnFile.add(mntmOpen);
		
		JMenuItem mntmSave = new JMenuItem("Save");
		mnFile.add(mntmSave);
		
		JMenuItem mntmClose = new JMenuItem("Close");
		mnFile.add(mntmClose);
		
		JMenu mnEdit = new JMenu("Edit");
		menuBar.add(mnEdit);
		
		JMenuItem mntmAddPokemon = new JMenuItem("Add Pokemon");
		mnEdit.add(mntmAddPokemon);
		
		JMenuItem mntmRemovePokemon = new JMenuItem("Remove Pokemon");
		mnEdit.add(mntmRemovePokemon);
		
		JMenuItem mntmDuplicatePokemon = new JMenuItem("Duplicate Pokemon");
		mnEdit.add(mntmDuplicatePokemon);
		
		JMenu mnHelp = new JMenu("Help");
		menuBar.add(mnHelp);
		
		JMenuItem mntmHowTo = new JMenuItem("How To");
		mnHelp.add(mntmHowTo);
		
		JMenuItem mntmAbout = new JMenuItem("About");
		mnHelp.add(mntmAbout);
		frame.getContentPane().setLayout(null);
		
		JSplitPane splitPane = new JSplitPane();
		splitPane.setBounds(0, 0, 624, 420);
		frame.getContentPane().add(splitPane);
		
		JPanel workPanel = new JPanel();
		splitPane.setRightComponent(workPanel);
		
		JPanel dataPanel = new JPanel();
		splitPane.setLeftComponent(dataPanel);
		
		JList list = new JList();
		dataPanel.add(list);
		list.setModel(new AbstractListModel() {
			String[] values = new String[] {"Abilities", "Connections", "Encounters", "Items", "Metadata", "Moves", "Phone", "Shadow Moves", "TMs", "Town Map", "Trainer Lists", "Trainers", "Trainer Types", "Types"};
			public int getSize() {
				return values.length;
			}
			public Object getElementAt(int index) {
				return values[index];
			}
		});
	}

	private void openFolder() {
		
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		if (e.getSource() == )
		
	}
}
