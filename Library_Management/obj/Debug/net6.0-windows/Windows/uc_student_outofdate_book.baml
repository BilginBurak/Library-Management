   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      :    4Library_Management.Windows.uc_student_outofdate_book   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  datagrd_duedatebook��5      $	��689��6[   $
��Left=�6g   $	��Top=�6�   $	��466��6�   $��	25,50,0,0q�6�      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�   $
��11.7(�6
  ���	#7FC8F79B   VerticalGridLinesBrush �	#CC41651F   HorizontalGridLinesBrush �	#CC41651F6T  �� 5   
   -   5         ��Name$ ısbn_txtbx��5      $
��Left=�6&   $��761,263,0,0q�6A    �� TextWrapping$ NoWrap=�6V   $	��Top=�6l   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�    �� 
IsReadOnly$
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ escrowdate_txtbx��5      $
��Left=�6,   $��761,352,0,0q�6G   $ NoWrap=�6\   $	��Top=�6r   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6   �� 5   
   -   5        $ booktitle_txtbx1��5      $
��Left=�6,   $��
761,84,0,0q�6G   $ NoWrap=�6[   $	��Top=�6q   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ author_txtbx��5      $
��Left=�6(   $��761,173,0,0q�6C   $ NoWrap=�6X   $	��Top=�6n   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ duedate_txtbx��5      $
��Left=�6)   $��761,441,0,0q�6D   $ NoWrap=�6Y   $	��Top=�6o   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5         ��Name$
 lbl3��5      $
��ISBN��6   $
��Left=�6-   $��761,238,0,0q�6H   $	��Top=�6]   $	��214��6u   $��15,0,5,0q�6�   $��Center=�6�   $��25��6�   �� 5   
   -	   5        $
 lbl4��5      $��Escrow Date��6   $
��Left=�64   $��761,327,0,0q�6O   $	��Top=�6d   $	��214��6|   $��15,0,5,0q�6�   $��Center=�6�   $��25��6�   �� 5   
   -
   5        $
 lbl1��5      $��
Book Title��6   $
��Left=�63   $��
761,59,0,0q�6N   $	��Top=�6b   $	��214��6z   $��15,0,5,0q�6�   $��Center=�6�   $��25��6�   $y�Visible=�6�   �� 5   
   -   5        $
 lbl2��5      $��Author��6   $
��Left=�6/   $��761,148,0,0q�6J   $	��Top=�6_   $	��214��6w   $��15,0,5,0q�6�   $��Center=�6�   $��25��6�   �� 5   
   -   5        $
 lbl5��5      $��Due Date��6   $
��Left=�61   $��761,416,0,0q�6L   $	��Top=�6a   $	��214��6y   $��15,0,5,0q�6�   $��Center=�6�   $��25��6�   �� 5   
   -   5        $ 	total_lbl��5      $��Label��6#   $
��Left=�63   $��
25,516,0,0q�6N   $	��Top=�6b   $	��305��6z   $��30��6�   $��Center=�6�   $��15,5,5,5q�6�   �� 5   
   -   5        $ late_lbl��5      $>��8You don't have a delayed book. Thanks for your attention��6"   $��Center=�6e   $��0,0,0,0q�6�   $��Center=�6�   $��25(�6�   $y�Hidden=�6�   5!      5"      