using IronBrew2.Bytecode_Library.Bytecode;
using IronBrew2.Bytecode_Library.IR;

namespace IronBrew2.Obfuscator.Opcodes
{
	public class OpReturn : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Return && instruction.B > 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A];
do return Unpack(Stk, A, A + Inst[OP_B] - 1) end;
";
	}
	
	public class OpReturnB0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Return && instruction.B == 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]; 
do return Unpack(Stk, A, Top) end;";
	}
	
	public class OpReturnB1 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Return && instruction.B == 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			"do return end;";
	}
}