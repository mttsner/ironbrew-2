using IronBrew2.Bytecode_Library.Bytecode;
using IronBrew2.Bytecode_Library.IR;

namespace IronBrew2.Obfuscator.Opcodes
{
	public class OpSetList : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.SetList && instruction.B != 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A];
local T = Stk[A];
for Idx = A + 1, A + Inst[OP_B] do 
	Insert(T, Stk[Idx])
end;";
	}
	
	public class OpSetListB0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.SetList && instruction.B == 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A];
local T = Stk[A];
for Idx = A + 1, Top do 
	Insert(T, Stk[Idx])
end;";
	}
}