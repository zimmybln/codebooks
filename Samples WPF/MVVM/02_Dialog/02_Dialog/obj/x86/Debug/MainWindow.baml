   M S B A M L   `   `   `  ����D  @02_Dialog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UseCase_02_DialogUseCase_02_Dialog  5   	   "    UseCase_02_Dialog.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /appclr-namespace:UseCase_02_Dialog     5   	     � Title$"  MVVM Beispiel für dotnetpro��5   	   $	��169��6-   $	��434��6:    � DataContext 5      '   !UseCase_02_Dialog.MainWindowModel  5   
   .��5	      � .+�5
   
   �� $��Dialog per Komposition��6   $��38��6e   $
��Left=�6q   $��	28,70,0,0q�6�   $	��Top=�6�   $	��171��6�   ��62   �� * RunDialogViaCompositionCommand+6�   �� 5   
   -   5        $��label1��5   �    �� ContentStringFormat$&  Der Wert der Eigenschaft ist {0}��6-   $��26��6d   $
��Left=�6p   $��	28,23,0,0q�6�   $	��Top=�6�   $	��359��6�   ��6   �� *
FooValue+6�   �� 5   
   $��Dialog per Constructor��6   $��38��6e   $
��Left=�6q   $��
216,70,0,0q�6�   $	��Top=�6�   $	��171��6�   ��62   �� * RunDialogViaConstructorCommand+6�   5      5      