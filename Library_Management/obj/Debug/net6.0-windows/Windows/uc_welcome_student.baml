   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      3    -Library_Management.Windows.uc_welcome_student   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        .��5	      �   J� IsHitTestVisible$  False��6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgrd��5
      $��465,30,10,490q�6M      HeadersVisibility$ Column=�6d      CanUserAddRows$ False��6      
IsReadOnly$
 True��6�      RowBackground �	#00000000   SelectionMode$ Single=�6�      SelectionUnit$
 Cell=�6     CanUserDeleteRows$ False��6  	   GridLinesVisibility$	 Vertical=�65  $��Right=�6T  $��0,0,0,0q�6w  
   RowDetailsVisibilityMode$
 	Collapsed=�6�  $��11(�6�  $��Bottom=�6�  4  .System.Windows.Automation.AutomationProperties   IsColumnHeader$
 True��6�  $	��560��6  $��LeftToRight=�6  $y�Hidden=�69  ��6�   Z� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Overdue Books:��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6=      CanUserSort$ False��6I      CanUserReorder$ False��6]      
IsReadOnly$
 True��6t    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%�   '        7 �� 5      8   "  6Q   .�5      ��  � ��
 ���� 63   �� 5       � ��$ 	ExtraBold"�63   5      5      5        5   
   -   5        $ dtgrdtotalread��5      $��	30,72,0,0q�6W   $ Column=�6j   $ False��6�   $
 True��6�   ���	#7FC8F79B �	#00000000$ Single=�6�   $
 Cell=�6  $ False��6"  $	 
Horizontal=�6<  $��Right=�6]  $��0,0,0,0q�6�  $
 	Collapsed=�6�  $��Bottom=�6�  $
 True��6�  $	��220��6  $��LeftToRight=�6  $y�Visible=�64  $	��557��6I  $
��Left=�6V  $	��Top=�6q  $��0,0,0,0q�6�  ��6�   Z�  5      ��%�   '        7 �� 5      8   "  6Q   .�5      ��  � ��
 ���� 63   �� 5       � ��$ 	ExtraBold"�63   5      5      5      �� 5   
   $��-Top Readers Corner-��6   $
��Left=�6/   $��	30,30,0,0q�6J   $	��Top=�6]   $	��220��6u   $��20(�6�   $��42��6�   ���	#7FC8F79B$��0,0,0,3q�6�   ���	#CC41651F6�   �� 5    
   -   5         ��Name$ lbl_totaluser��5       $��Label��6'   $
��Left=�67   $��657,459,0,0q�6R   $	��Top=�6g   $	��335��6   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  �� 5!   
   -   5        $ lbl_activeuser��5!      $��Label��6(   $
��Left=�68   $��657,505,0,0q�6S   $	��Top=�6h   $	��335��6�   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  �� 5"   
   -   5        $ lbl_totalbook��5"      $��Label��6'   $
��Left=�67   $��657,551,0,0q�6R   $	��Top=�6g   $	��335��6   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  �� 5#   
   -   5        $ lbl_totalborrow��5#      $��Label��6)   $
��Left=�69   $��657,597,0,0q�6T   $	��Top=�6i   $	��335��6�   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  5$      5%      