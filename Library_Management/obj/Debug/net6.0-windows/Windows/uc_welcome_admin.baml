   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      1    +Library_Management.Windows.uc_welcome_admin   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  dtgrdtotalread��5      $��	30,72,0,0q�6W      HeadersVisibility$ Column=�6j      
IsReadOnly$
 True��6�   ���	#7FC8F79B   RowBackground �	#00000000   SelectionMode$ Single=�6�      SelectionUnit$
 Cell=�6�      CanUserDeleteRows$ False��6     GridLinesVisibility$ 
Horizontal=�6%  $��Right=�6F  $��0,0,0,0q�6i     RowDetailsVisibilityMode$ 	Collapsed=�6�  $��Bottom=�6�  4  .System.Windows.Automation.AutomationProperties	   IsColumnHeader$
	 True��6�  $	��220��6�  $��LeftToRight=�6  $y�Visible=�6  $	��557��62  $
��Left=�6?  $	��Top=�6Z  $��0,0,0,0q�6r  
   CanUserAddRows$
 False��6�  ��6�   Z�  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%�   '        7 �� 5      8   "  6Q   .�5      ��  � ��
 ���� 63   �� 5       � ��$ 	ExtraBold"�63   5      5      5      �� 5   
   $��-Top Readers Corner-��6   $
��Left=�6/   $��	30,30,0,0q�6J   $	��Top=�6]   $	��220��6u   $��20(�6�   $��42��6�   ���	#7FC8F79B$��0,0,0,3q�6�   ���	#CC41651F6�   �� 5   
   -   5         ��Name$ lbl_totaluser��5      $��Label��6'   $
��Left=�67   $��638,453,0,0q�6R   $	��Top=�6g   $	��335��6   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  �� 5   
   -   5        $ lbl_activeuser��5      $��Label��6(   $
��Left=�68   $��638,500,0,0q�6S   $	��Top=�6h   $	��335��6�   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  �� 5   
   -   5        $ lbl_totalbook��5      $��Label��6'   $
��Left=�67   $��638,546,0,0q�6R   $	��Top=�6g   $	��335��6   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  �� 5   
   -   5        $ lbl_totalborrow��5      $��Label��6)   $
��Left=�69   $��638,592,0,0q�6T   $	��Top=�6i   $	��335��6�   $��32��6�   $
��Left=�6�   $��Center=�6�   ���	#CC41651F$��0,0,0,1q�6�   $��16(�6  5      5      