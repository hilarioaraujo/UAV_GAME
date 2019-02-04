using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAV_GAME_FINAL
{
    class ComboBoxEx
    
        Friend Structure ItemCor;
   Public Texto As String
   Public Cor As Color
   Public Overrides Function ToString() As String
       Return Texto
   End Function
End Structure

Public Class ComboBoxEx
   Inherits ComboBox

   Sub New()
       Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
   End Sub

   Public Sub AdicionarItem(Texto As String, Cor As Color)
       Me.Items.Add(New ItemCor With {.Cor = Cor, .Texto = Texto })
   End Sub

   Public Function CorSeleccionada() As Color
       If Me.SelectedIndex = -1 Then Return Nothing
       Return DirectCast(Me.Items(Me.SelectedIndex), ItemCor).Cor
   End Function

   Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
       e.DrawBackground()
       e.DrawFocusRectangle()
       Dim tmpItem As ItemCor = DirectCast(Me.Items(e.Index), ItemCor)
       Dim tmpCorLetra As Brush = New SolidBrush(tmpItem.Cor)
       If e.State = Windows.Forms.DrawItemState.Selected Then tmpCorLetra = Brushes.White
       Dim tmpFont As New Font(Me.Font, FontStyle.Bold)
       e.Graphics.DrawString(tmpItem.Texto, tmpFont, tmpCorLetra, e.Bounds)
   End Sub
End Class
    }
}
