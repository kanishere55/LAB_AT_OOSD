public class CTuGiac extends CHinhVe {
    protected CDiem p1, p2, p3, p4;

    public CTuGiac(CDiem p1, CDiem p2, CDiem p3, CDiem p4) {
        super(2);
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
    }

    @Override
    public float dienTich() {
        float s1 = p1.getX() * p2.getY() + p2.getX() * p3.getY() + p3.getX() * p4.getY() + p4.getX() * p1.getY();

        float s2 = p1.getY() * p2.getX() + p2.getY() * p3.getX() + p3.getY() * p4.getX() + p4.getY() * p1.getX();

        return Math.abs(s1 - s2) / 2;
    }

    @Override
    public float chuVi() {
        return p1.khoangCach(p2) + p2.khoangCach(p3) + p3.khoangCach(p4) + p4.khoangCach(p1);
    }

    @Override
    public void ve() {
        System.out.println("Ve tu giac");
    }
}