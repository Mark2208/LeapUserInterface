   M S B A M L   `   `   `  ����L  HLeapUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LeapUserInterfaceLeapUserInterface  5   	   "    LeapUserInterface.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LeapUserInterface     5   	   -   5          �Name$  
BackWindow��5   	    � Title$ 
MainWindow��5   	   $	��320��6   $	��370��6)    � AllowsTransparency .  � WindowStyle$
 None=�6O    J� Opacity$ 0.805Q�6b   .��5	      � -   5         �Name$ BackGrid��5	      $��0,0,-0.333,0q�6   ���	#FF464646.+�5
   
   �� -   5         ��Name$ label��5
      $��
Left Hand:��6   $
��Left=�64   $��	29,32,0,0q�6O   $	��Top=�6b   ���	#FFA5A5A56z   �� 5   
   -   5        $ 
LBL_L_Hand��5      $	��N/A��6$   $
��Left=�62   $��
121,32,0,0q�6M   $	��Top=�6a   ���	#FFA5A5A5$��89��6�   �� 5   
   -   5         ��Name$ BT_ResumeTracking��5      $��Start Tracking��6,   $
��Left=�6E   $��217,231,0,0q�6`   $	��Top=�6u   $	��132��6�   $��62��6�   ���	#FFD8D8D8���	#FF171717��6�   Z�  � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%_   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 30��65   5      5      5      �� 5   
   -   5        $ BT_PauseTracking��5      $��Pause Tracking��6+   $
��Left=�6D   $��219,149,0,0q�6_   $	��Top=�6t   $	��130��6�   $��62��6�   ���	#FFD8D8D8���	#FF171717��6�   Z�  5      ��%_   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 30��65   5      5      5      �� 5   
   -   5        $ BT_Close��5      $��X��6#   $
��Left=�6/   $��
309,10,0,0q�6J   $	��Top=�6^   $��40��6v   $��40��6�    J� RenderTransformOrigin$ -0.451,-0.188&�6�   ���	#FF171717���	#FFD8D8D8��6�   Z�  5      ��%`   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$	 100��65   5      5       5!      �� 5"   
   -   5        $ BT_Minimize��5"      $��-��6&   $
��Left=�62   $��
256,10,0,0q�6M   $	��Top=�6a   $��40��6y   $��40��6�   $ -0.451,-0.188&�6�   ���	#FF171717���	#FFD8D8D8��6�   Z�  5#      ��%`   '��       �� 5$      "	 ��6   .�5%      �� 
 �@��CornerRadius$	 100��65   5&      5'      5(      �� 5)   
   -	   5        $ 	LBL_Debug��5)      $��Debug��6#   $
��Left=�63   $��121,275,0,0q�6N   $	��Top=�6c   
�������6{   5*      5+      