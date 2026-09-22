public abstract class CHinhVe {
    protected int maLoaiHinhVe;

    public CHinhVe(int maLoaiHinhVe) {
        this.maLoaiHinhVe = maLoaiHinhVe;
    }

    public abstract float dienTich();

    public abstract float chuVi();

    public abstract void ve();
}