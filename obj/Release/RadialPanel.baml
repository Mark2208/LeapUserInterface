   M S B A M L   `   `   `  ���� L  HLeapUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LeapUserInterfaceLeapUserInterface  #    LeapUserInterface.RadialPanel   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:LeapUserInterface       � Title$  RadialPanel��$	��208��$	��208�� � AllowsTransparency .  � WindowStyle$
 None=����	#FFF0F0F0 J� Opacity$	 0.6Q� � 	Resources    RadialScaleAnimation �� 
TargetType �� Triggers P� Property P� Value	 N� ExitActions
 �� TargetProperty	 W� To g� Duration g� AutoReverse	 �� To��%�   &	        �� " A� P�  � {� . 	 �� .���� .��W� $
 Width�$ 62X�$ 0:0:0.3D� . W� $
 Height�$ 62X�$ 0:0:0.3D� . �� $
 
Fill.Color�$ DarkCyanX�$ 0:0:0.5D� .  J� Clip ��  �� Rect$ 0,0,208,208� �� RadiusX$	 208Q� �� RadiusY$	 208Q�.��� -    �Name$ BackGrid�����	#FF464646.+�A� -    A�Name$ 	Radial_Q1�����	#FF171717$
��Left=�$��56��$��
109,15,0,0q�$	��Top=�$��56��#��[  A� -   $ 	Radial_Q8�����	#FF171717$
��Left=�$��56��$��	43,15,0,0q�$	��Top=�$��56��#��[  A� -   $ 	Radial_Q7�����	#FF171717$
��Left=�$��56��$��8,75,0,0q�$	��Top=�$��56��#��[  A� -   $ 	Radial_Q2�����	#FF171717$
��Left=�$��56��$��
144,75,0,0q�$	��Top=�$��56��#��[  A� -   $ 	Radial_Q6�����	#FF171717$
��Left=�$��56��$��
43,135,0,0q�$	��Top=�$��56��#��[  A� -   $ 	Radial_Q3�����	#FF171717$
��Left=�$��56��$��109,135,0,0q�$	��Top=�$��56��#��[  �� -    ��Name$ LBL_SkipForward��$��=🞂��$
��Left=�$��
160,85,0,0q�$	��Top=�$��16(����	#FFDFDFDF�� -	   $ 
label_Copy��$��🞀=��$
��Left=�$��	21,85,0,0q�$	��Top=�$��16(����	#FFDFDFDF�� -
   $ label_Copy1��$��+🕨��$
��Left=�$��122,146,0,0q�$	��Top=�$��16(����	#FFDFDFDF�� -   $ label_Copy2��$��-🕨��$
��Left=�$��
58,146,0,0q�$	��Top=�$��16(����	#FFDFDFDF�� -   $ label_Copy3��$	��⌃��$
��Left=�$��
127,28,0,0q�$	��Top=�$��16(����	#FFDFDFDF�� -   $ label_Copy4��$	��⌄��$
��Left=�$��	59,21,0,0q�$	��Top=�$��16(����	#FFDFDFDF J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -0.782Q�T� A� -   $ Ellipse_LeftSignal�����	#FFCECECE$
��Left=�$��18��$	��Top=�$��18��$��	95,93,0,0q�