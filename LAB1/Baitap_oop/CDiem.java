public class CDiem {
    protected float x, y;

    public CDiem(float x, float y) {
        this.x = x;
        this.y = y;
    }

    public float getX() {
        return x; 
    }
    public float getY() {
        return y; 
    }

    public float khoangCach(CDiem diem) {
        float dx = this.x - diem.x;
        float dy = this.y - diem.y;
        return (float) Math.sqrt(dx * dx + dy * dy);
    }
}