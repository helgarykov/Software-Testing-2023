using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Lab_3;

/// TODO :
/// The input file contains the initial state of the grid in the game "2048".
/// In this game, the grid size is 4 by 4 cells. Each cell contains a number that
/// is a power of two (2, 4, 8, etc.). The grid can be shifted left, right, up, or down.
///
///0 0 0 0
///2 0 2 0
///1 1 1 1
///0 4 0 8	shift right	0 0 0 0
///                     0 0 0 4
///                     0 0 2 2
///                     0 0 4 8

/// If different numbers collide - they do not merge.
/// L - shift left
/// R - shift right
/// U - shift up
/// D - shift down
/// The input file contains the initial state of the grid and
/// a sequence of moves separated by spaces. The moves are denoted by letters:
/// 1. 
/// 2. 
///
///




