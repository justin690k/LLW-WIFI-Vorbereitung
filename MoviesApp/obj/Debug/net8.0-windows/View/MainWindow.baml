   M S B A M L   `   `   `  ����D  @MoviesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MoviesApp	MoviesApp  5   	   9!clr-namespace:MoviesApp.ViewModelMoviesApp.ViewModel  5   	   K GMoviesApp.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[?clr-namespace:MoviesApp.Domain.Models;assembly=MoviesApp.DomainMoviesApp.Domain.Models 5   	       MoviesApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MoviesApp     5   	   7	viewmodel!clr-namespace:MoviesApp.ViewModel     5   	   Qmodel?clr-namespace:MoviesApp.Domain.Models;assembly=MoviesApp.Domain     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5         boolToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   o� .@�5      m� $	��Add��6    m� Command 6$   �� *ToggleAddPopUpCommand+m� 5      $
��Edit��6    6%   �� *ToggleEditPopUpCommand+m� 5      $��Remove��6    6'   �� *RemoveMovieCommand+ m� CommandParameter 5      �� *SelectedItem.Id+5      �� 5   
   $��1��6   ��5      �� *Movies+ �� SelectedItem 5       �� *SelectedItem+��5!      �� 5"       �� DataType$ model:Movie��6   .R�5#      ��  �� Orientation$ 
Horizontal=�6!   .+�5$      �� ��6    �� *Id+�� 5%      ��6    �� *Title+�� 5&      ��6    �� *Genre.GenreValue+�� 5'      ��6    �� *Director.Firstname+�� 5(      ��6    �� *Director.Lastname+5)      5*      5,      �� 5/   
   $��2��6   $��10q�51      
������� �� CornerRadius$ 10��53      
���   �$��1q�55      y�50      �� *ShowAddPopUp+	 �� 	Converter#	 [  ._�56      � .+�57      �� 
���   �$��1q�58      $ 45��59      $��Right=�5:      $	��Top=�5;      $��20��5<      $��20��5=      ._�5>      �� $��X��6   
���������5@      �� *ToggleAddPopUpCommand+5A      �� 5B      .+�5C      �� 
 � DataContext
 6!   �� *SelectedItem+.+�5D      �� $ 
Horizontal=�6%   .+�5E      �� $��Title:��6$   �� 5F      ��6&   �� *Title+5G      �� 5I      $ 
Horizontal=�6%   .+�5J      �� $��Genre:��6$   �� 5K       �� DisplayMemberPath$ Id��5L   '    5K   '   �� *Genre+��5M   '   �� *Genres+ �� RelativeSource ��  �� AncestorType'   !MoviesApp.ViewModel.MainViewModel"   �� Mode$ FindAncestor=�5N      �� 5P      $ 
Horizontal=�6%   .+�5Q      �� $��	Director:��6$   �� 5R      $ Id��5S   '    5R   '   �� *
Director+��5T   '   �� *	Directors+ �� "  $ FindAncestor=�5U      5V      �� 5X      $	��Add��6   ��6+   �� *AddMovieCommand+5Y      5Z      5[      5\      5]      