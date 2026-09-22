public class CEllipse extends CHinhVe {
    protected CDiem tam;
    protected float a;
    protected float b;

    public CEllipse(CDiem tam, float a, float b) {
        super(3);
        this.tam = tam;
        this.a = a;
        this.b = b;
    }

    @Override
    public float dienTich() {
        return (float) (Math.PI * a * b);
    }

    @Override
    public float chuVi() {
        return (float) (2 * Math.PI * Math.sqrt((a * a + b * b) / 2));
    }

    @Override
    public void ve() {
        System.out.println("Ve ellipse");
    }
}