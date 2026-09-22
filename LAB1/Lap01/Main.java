public class Main {
    public static void main(String[] args) {
        CHinhVe[] danhSachHinhVe = new CHinhVe[3];

        danhSachHinhVe[0] = new CTamGiac(
                new CDiem(0, 0),
                new CDiem(4, 0),
                new CDiem(0, 3));

        danhSachHinhVe[1] = new CTuGiac(
                new CDiem(0, 0),
                new CDiem(4, 0),
                new CDiem(4, 3),
                new CDiem(0, 3));

        danhSachHinhVe[2] = new CEllipse(
                new CDiem(0, 0), 4, 2);

        for (CHinhVe hinhVe : danhSachHinhVe) {
            hinhVe.ve();
            System.out.println("Dien tich: " + hinhVe.dienTich());
            System.out.println("Chu vi: " + hinhVe.chuVi());
            System.out.println();
        }
    }
}