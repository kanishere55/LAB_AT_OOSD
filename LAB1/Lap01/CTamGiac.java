public class CTamGiac extends CHinhVe {
    protected CDiem p1, p2, p3;

    public CTamGiac(CDiem p1, CDiem p2, CDiem p3) {
        super(1);
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
    }

    @Override
    public float dienTich() {
        float a = p1.khoangCach(p2);
        float b = p2.khoangCach(p3);
        float c = p3.khoangCach(p1);
        float p = (a + b + c) / 2;

        return (float) Math.sqrt(p * (p - a) * (p - b) * (p - c));
    }

    @Override
    public float chuVi() {
        return p1.khoangCach(p2) + p2.khoangCach(p3) + p3.khoangCach(p1);
    }

    @Override
    public void ve() {
        System.out.println("Ve tam giac");
    }
}