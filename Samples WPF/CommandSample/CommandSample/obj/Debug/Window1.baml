   M S B A M L   `   `   `  ����H  DCommandSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CommandSampleCommandSample  5          CommandSample.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      +localclr-namespace:CommandSample    5        � Title$  Window1��5      $	��474��6   $	��644��6"    � 	Resources 5         	Testblock��%Q   &	        �� 5   
   /-Das ist ein Test, in dem wir etwas eintragen.5	      5
       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$$ local:MyCommands.SimpleCommand��5      6B   .��5      � .+�5   
   o� -   5        $��menu1��5      $��22��6   $	��Top=�6(   .@�5      m� $��Befehle��6   .@�5      m� $��Ohne Parameter��6    m� Command$$ local:MyCommands.SimpleCommand��63   m� 5      $��Direkter Wert��6   $$ local:MyCommands.SimpleCommand��62    m� CommandParameter$ Das ist ein direkter Wert��6[   m� 5      $ ��Verweis auf globale Klasse��6   $$ local:MyCommands.SimpleCommand��6?    6h   ��  �� Current �� Source# Z  �� Path$ 	TestClass�5      5      �� 5   
   -   5        $��cmdWithoutParameter��5   X   $$��local:MyCommands.SimpleCommand��6   $��23��6:   $��8,30,0,0q�6F   $	��Top=�6s   $
��Left=�6�   $	��283��6�   .��6�   Ohne Parameter6�   �� 5   
   -   5        $��cmdDirectParameter��5   �   $$��local:MyCommands.SimpleCommand��6   $��Hallo, das ist ein Wert��6:   $��23��6f   $��8,92,0,0q�6r   $	��Top=�6�   $
��Left=�6�   $	��283��6�   .��6�   Parameter direkt übergeben6�   �� 5   
   -   5        $��cmdSelfProperty��5   �   $$��local:MyCommands.SimpleCommand��6   $��	8,128,0,0q�6�   $
��Left=�6�   $	��283��6�   $��24��6�   $	��Top=�6�   ��6:   �� 	 �� ElementName$	 txtParameterValue��$
 Text�.��6�   ,*Parameter ist Verweis auf Eigenschaftswert6!  �� 5   
   -   5        $��txtParameterValue��5   A   $
��Left=�6   $��
85,161,0,0q�6-   $	��206��6Z   $��23��6f   $	��Top=�6r   �� 5   
   -   5        $��label1��5   >   $
��Left=�6   $��	8,159,0,0q�6+   $��70��6L   $��26��6W   $	��Top=�6c   .��6{   Wert:6�   �� 5   
   -   5        $��lstCommandResults��5   (   $��296,30,10,12q�6   
 � ContextMenu
 5      �� 5      .@�5      m� $��lokaler Befehl��6   $$ local:MyCommands.SimpleCommand��67    6`   ��  �� RelativeSource ��  �� AncestorType$ ContextMenuL�$" PlacementTarget.SelectedItem�m� 5       $��globaler Befehl��6   $$ local:MyCommands.SampleCommand��68    6a   ��  �� $ ContextMenuL�$" PlacementTarget.SelectedItem�5!      5#      �� 5$   
   -	   5        $��button1��5$   �   $$��local:MyCommands.SimpleCommand��6   $
��Left=�6�   $��	8,192,0,0q�6�   $	��283��6�   $��23��6�   $	��Top=�6�   ��6:   �� $	 lstCommandResults��$ SelectedItem�.��6�   !Parameter als Verweis auf Liste6  �� 5%   
   -
   5        $��button2��5%   �   $$��local:MyCommands.SimpleCommand��6   $��23��6�   $��8,61,0,0q�6�   $	��Top=�6�   $
��Left=�6�   $	��283��6�   ��6:   ��  �� *Self+$ Command.Text�.��6�   '%Parameter als Verweis auf das Command6"  �� 5&   
   -   5        $��button3��5&   �   $$��local:MyCommands.SimpleCommand��6   $��23��6�   $
��Left=�6�   $��	8,0,0,188q�6�   $��Bottom=�6�   $	��283��6�   ��6:   �� # [  $
 Text�.��6�   '%Verweis auf eine Ressource im Fenster6  �� 5'   
   -   5        $��button4��5'   �   $$��local:MyCommands.SimpleCommand��6   $��23��6�   $
��Left=�6�   $��	8,0,0,156q�6�   $��Bottom=�6  $	��283��6  ��6:   ��  �� *FindAncestor+" �$ ParameterValue�.��6(  )'Verweis auf eine Eigenschaft im Fenster6Q  �� 5(   
   -   5        $��button5��5(   �   $$��local:MyCommands.SimpleCommand��6   $��23��6�   $
��Left=�6�   $��	8,0,0,125q�6�   $��Bottom=�6�   $	��283��6�   ��6:   ��   Anwendungsbeschreibung# [ $
 Text�.��6  $"Verweis auf eine globale Ressource6%  �� 5)   
   -   5        $��button6��5)   �   $$��local:MyCommands.SimpleCommand��6   $��23��6�   $
��Left=�6�   $��	10,0,0,75q�6�   $��Bottom=�6�   $	��283��6�   ��6:   �� # Z $ 	TestClass�.��6�   &$Verweis auf eine globale Eigenschaft6#  �� 5*   
   -   5        $��button7��5*   �   $$��local:MyCommands.SampleCommand��6   $��23��6�   $
��Left=�6�   $��	59,0,0,29q�6�   $��Bottom=�6�   $��75��6�   ��6:   �� # Z $ 	TestClass�.��6�   Button6  5+      5,      