   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Library_ManagementLibrary_Management  5          Library_Management.App   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2local clr-namespace:Library_Management     5        �� 	Resources  5   
      tabitem �� 
TargetType �� Property �� Value  RoundCorner �� 	Resources  Triggers  Buttonround_corner �� 
TargetType  PasswordBoxStyle-  'System.Windows.Input.KeyboardNavigation ��Name �� CornerRadius J� SnapsToDevicePixels	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value��%�  &	        &	 G     &	 �     &	 i    &	 �    �� 5   
   " ��6    .�5      ��  � ��$ 3q�6(   5      �� 5    
    5!      ���� 5"      '��       " ��6   .�5#      ��  �@��CornerRadius$ 15��65   5$      5%      5&      �� 5+   
    5,      ���� 5-      '��       " ��6   .�5.      ��  �@��CornerRadius$ 15��65   5/      50      57      �� 5;   
   " ��6+    5<      ���� 5=      '��       " ��6   .�5>      ��  �@��CornerRadius$ 15��65   5?      5@      .�5A      ��  � ��
 � ���6+   �� 5C       � �� 5D      �� 5E      " ��6&   .R�5F      �� #��z��6!   ._�5G      �� $��Center=�6/   $��Center=�6L   5H      5K      5M      5S      �� 5W   
   " G�6)   .�5X      ��  �@G�PasswordChar$	 ●��6$   �� 5Y       � �� �#5252526"   �� 5Z       � ��
 �����6#   �� 5[       � ��
 �����6"   �� 5\       � ��$ 0,0,0,2q�6'   �� 5]       �@ TabNavigation$
 None=�68   �� 5^       � ��$
 Left=�62   �� 5_       �@�FocusVisualStyle 6(   Z� �� 5`       �@J�	AllowDrop$
 true��6!   �� 5a       �@��PanningMode$ VerticalFirst=�60   �� 5b       �@��IsFlicksEnabled$ False��6.   �� 5c       � �� 5d      �� 5e      " G�6   .R�5f      �� $ border��6   $ 15��6%   #��z��67   #��z��6a   #��z��6�   $
 True��6�   ._�5g      �� $	 PART_ContentHost��6   $|�false��68   $��Hidden=�6J   $��Hidden=�6q   5h      
 5i      P� 5j       � {�$ false��6.   . �5k      �� $ border��6.    �@J�Opacity$
 0.56Q�6B   5l      P� 5m       �@J�IsMouseOver$
 true��60   . �5n      �� $ border��62    � �� �	#FF7EB4EA6F   5o      P� 5p       �@J�IsKeyboardFocused$
 true��66   . �5q      �� $ border��62    � �� �	#FF569DE56F   5r      5t      5v       5w      ]� 5x       5y      �� 5z      + �@G�#IsInactiveSelectionHighlightEnabled$
 true��6G   �� 5{       �@G�IsSelectionActive$ false��65   ./�5}      ��  �@G�SelectionBrush# � /�6,   5~   	   5�      5�      5�      