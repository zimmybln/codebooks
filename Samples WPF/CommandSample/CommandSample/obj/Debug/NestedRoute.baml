   M S B A M L   `   `   `  ����H  DCommandSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CommandSampleCommandSample  5          CommandSample.NestedRoute   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      +localclr-namespace:CommandSample    5        � Title$  NestedRoute��5      $	��386��6   $	��824��6&    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$# local:MyCommands.RouteCommand��5      6U   .��5	      � 
���P��.+�5
   
    � -   5        $��frame1��5
   $   $��
0,38,16,32q�6   $��Right=�62   $	��357��6N   
���<��  � Source$ ../Pages/InnerPage.xaml?�6o   �� 5   
   -   5        $��
cmdExecute��5   �   $��30��6   $#��local:MyCommands.RouteCommand��6   $
��Left=�6�   $��
215,0,0,32q�6�   $��Bottom=�6�   $	��118��6�   ��6E   ��  �� ElementName$ frame1�� �� Path$ Content�.��6�   Button6�   �� 5   
   -   5        $��lstReceives��5   A   $
��Left=�6   $��
24,24,0,96q�6-   $	��365��6T   5      5      