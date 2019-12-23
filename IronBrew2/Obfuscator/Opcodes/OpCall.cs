using IronBrew2.Bytecode_Library.Bytecode;
using IronBrew2.Bytecode_Library.IR;

namespace IronBrew2.Obfuscator.Opcodes
{
	public class OpCall : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B > 1 &&
			instruction.C > 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
local Results = { Stk[A](Unpack(Stk, A + 1, A + Inst[OP_B] - 1)) };
local Edx = 0;
for Idx = A, A + Inst[OP_C] - 2 do 
	Edx = Edx + 1;
	Stk[Idx] = Results[Edx];
end
";
	}
	
	public class OpCallB0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B == 0 &&
			instruction.C > 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
local Results = { Stk[A](Unpack(Stk, A + 1, Top)) };
local Edx = 0;
for Idx = A, A + Inst[OP_C] - 2 do 
	Edx = Edx + 1;
	Stk[Idx] = Results[Edx];
end
";
	}

	public class OpCallB1 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B == 1 &&	
			instruction.C > 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
local Results = { Stk[A]() };
local Limit = A + Inst[OP_C] - 2;
local Edx = 0;
for Idx = A, Limit do 
	Edx = Edx + 1;
	Stk[Idx] = Results[Edx];
end
";
	}
	
	public class OpCallC0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B > 1 &&
			instruction.C == 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
local Results, Limit = _R(Stk[A](Unpack(Stk, A + 1, A + Inst[OP_B] - 1)))
Top = Limit + A - 1
local Edx = 0;
for Idx = A, Top do 
	Edx = Edx + 1;
	Stk[Idx] = Results[Edx];
end;
";
	}
	
	public class OpCallC1 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B > 1 &&
			instruction.C == 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
Stk[A](Unpack(Stk, A + 1, A + Inst[OP_B] - 1))
";
	}
	
	public class OpCallB0C0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B == 0 &&
			instruction.C == 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
local Results, Limit = _R(Stk[A](Unpack(Stk, A + 1, Top)))
Top = Limit + A - 1
local Edx = 0;
for Idx = A, Top do 
	Edx = Edx + 1;
	Stk[Idx] = Results[Edx];
end;
";
	}
	
	public class OpCallB0C1 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B == 0 &&
			instruction.C == 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
Stk[A](Unpack(Stk, A + 1, Top))
";
	}
	
	public class OpCallB1C0 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B == 1 &&
			instruction.C == 0;

		public override string GetObfuscated(ObfuscationContext context) =>
			@"
local A = Inst[OP_A]
local Results, Limit = _R(Stk[A]())
Top = Limit + A - 1
local Edx = 0;
for Idx = A, Top do 
	Edx = Edx + 1;
	Stk[Idx] = Results[Edx];
end;
";
	}
	
	public class OpCallB1C1 : VOpcode
	{
		public override bool IsInstruction(Instruction instruction) =>
			instruction.OpCode == Opcode.Call && instruction.B == 1 &&
			instruction.C == 1;

		public override string GetObfuscated(ObfuscationContext context) =>
			"Stk[Inst[OP_A]]();";
	}
}