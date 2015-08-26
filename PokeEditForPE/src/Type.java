
public class Type {
	private int id;
	private String name;
	private String internalName;
	private String[] weaknesses;
	private String[] resistances;
	private String[] immunities;
	
	public Type() { }
	
	public Type(int i, String n, String iName, String[] weak, String[] res, String[] imm) {
		setId(i);
		setName(n);
		setInternalName(iName);
		setWeaknesses(weak);
		setResistances(res);
		setImmunities(imm);
	}

	
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getInternalName() {
		return internalName;
	}

	public void setInternalName(String internalName) {
		this.internalName = internalName;
	}

	public String[] getWeaknesses() {
		return weaknesses;
	}

	public void setWeaknesses(String[] weaknesses) {
		this.weaknesses = weaknesses;
	}

	public String[] getResistances() {
		return resistances;
	}

	public void setResistances(String[] resistances) {
		this.resistances = resistances;
	}

	public String[] getImmunities() {
		return immunities;
	}

	public void setImmunities(String[] immunities) {
		this.immunities = immunities;
	}
}
