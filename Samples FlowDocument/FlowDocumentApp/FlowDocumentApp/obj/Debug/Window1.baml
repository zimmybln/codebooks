   M S B A M L   `   `   `  ����J  FFlowDocumentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:FlowDocumentApp.FlowDocumentsFlowDocumentApp.FlowDocuments  5          FlowDocumentApp.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      =flowdoc+clr-namespace:FlowDocumentApp.FlowDocuments    5        � Title$  Window1��5      $	��330��6   $	��400��6"   .��5      ��  � 	Resources 5   
      
DataSource��%�  &	        � 5      .��5	      ��<NorthwindNames xmlns="">
                        <Person FirstName="Nancy" LastName="Davolio" />
                        <Person FirstName="Andrew" LastName="Fuller" />
                        <Person FirstName="Janet" LastName="Leverling" />
                        <Person FirstName="Margaret" LastName="Peacock" />
                        <Person FirstName="Steven" LastName="Buchanan" />
                    </NorthwindNames>        5      5      .+�5   
   �� ��6   ��  �� Source# [   �� XPath$ NorthwindNames/Person�� �� View 5      �� 5      .P�5      �� $��
First name��6%    �� DisplayMemberBinding 69   �� $ 
@FirstName���� 5      $��	Last name��6%    68   �� $ 	@LastName��5      5      ,� 5   
   .��5      /� .T�5      0   *FlowDocumentApp.FlowDocuments.ItemsContent     ItemsSource 6'   �� # [  $ NorthwindNames/Person��   
ItemsPanel 5      �� 5       .R�5!      ,   &FlowDocumentApp.FlowDocuments.Fragment     Content. 5"   "   �� 	 �� BorderThickness$	 1q�6(   
 �� BorderBrush

 �   �.�5#   &   �� ,   &FlowDocumentApp.FlowDocuments.Attached   IsItemsHost . .�5$   *   �� 
����ح�.�5%   .   �� .�5&   2   J� .*�6<   
First name6H   5'   /   �� 5(   .   .�5)   2   J� .*�6<   	Last name6G   5*   /   5+   +   5,   '   5-   #   5.      5/         ItemTemplate 51      �� 52      .R�53        . 54   "   �� .�55   &   �� .�56   *   J� .*�64   .*�57   .   /   )FlowDocumentApp.FlowDocuments.BindableRun     	BoundText 6B   �� $ 
@FirstName��58   +   59   '   �� 5:   &   .�5;   *   J� .*�64   .*�5<   .      6B   �� $ 	@LastName��5=   +   5>   '   5?   #   5@      5A      5C      5D      5E      5F      5G      