/*
	Genotypic frequencies at equilibrium for polysomic inheritance under double-reduction
	Kang Huang, Tongcheng Wang, Derek W. Dunn, Pei Zhang, Rucong Liu, Xiaoxiao Cao, Baoguo Li
	doi: https://doi.org/10.1101/532861
	Feb 27, 2019 
*/

#ifndef DRE_H
#define DRE_H

extern "C" {
#ifdef _WIN32
	#define EXPORT __declspec(dllexport)
#else
	#define EXPORT 
#endif
	
EXPORT unsigned int GetHash(int* x, int* y, int p);
EXPORT void MatchAllele(long long code, int *gx, int * gy, int *alleles, int offset, int p);
EXPORT double Thomas2000LikelihoodIn(double h2, double vp, double* vx2, double* prfs, double f, int n, int v);
EXPORT double Mousseau1998LikelihoodIn(double h2, double* vx2, double* prfs, double f, int n, int v);
EXPORT double GFZ10_iiiiiiiiii(double a1, double a2, double pi);
EXPORT double GFZ10_iiiiiiiiij(double a1, double a2, double pi, double pj);
EXPORT double GFZ10_iiiiiiiijj(double a1, double a2, double pi, double pj);
EXPORT double GFZ10_iiiiiiiijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiiiiijjj(double a1, double a2, double pi, double pj);
EXPORT double GFZ10_iiiiiiijjk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiiiiijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiiiijjjj(double a1, double a2, double pi, double pj);
EXPORT double GFZ10_iiiiiijjjk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiiiijjkk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiiiijjkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiiiijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iiiiijjjjj(double a1, double a2, double pi, double pj);
EXPORT double GFZ10_iiiiijjjjk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiiijjjkk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiiijjjkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiiijjkkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiiijjklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iiiiijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ10_iiiijjjjkk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiijjjjkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiijjjkkk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ10_iiiijjjkkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiijjjklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iiiijjkkll(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiiijjkklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iiiijjklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ10_iiiijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double GFZ10_iiijjjkkkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiijjjkkll(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ10_iiijjjkklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iiijjjklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ10_iiijjkkllm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iiijjkklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ10_iiijjklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double GFZ10_iiijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
EXPORT double GFZ10_iijjkkllmm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ10_iijjkkllmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ10_iijjkklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double GFZ10_iijjklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
EXPORT double GFZ10_iijklmnopq(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq);
EXPORT double GFZ10_ijklmnopqr(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq, double pr);
EXPORT double PFZ10_i(double a1, double a2, double pi);
EXPORT double PFZ10_ij(double a1, double a2, double pi, double pj);
EXPORT double PFZ10_ijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double PFZ10_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double PFZ10_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double PFZ10_ijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double PFZ10_ijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double PFZ10_ijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
EXPORT double PFZ10_ijklmnopq(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq);
EXPORT double PFZ10_ijklmnopqr(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq, double pr);
EXPORT double GFG10_iiiii(double a1, double a2, double pi);
EXPORT double GFG10_iiiij(double a1, double a2, double pi, double pj);
EXPORT double GFG10_iiijj(double a1, double a2, double pi, double pj);
EXPORT double GFG10_iiijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFG10_iijjk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFG10_iijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFG10_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double PFG10_i(double a1, double a2, double pi);
EXPORT double PFG10_ij(double a1, double a2, double pi, double pj);
EXPORT double PFG10_ijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double PFG10_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double PFG10_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);

EXPORT double GFZ8_iiiiiiii(double a1, double a2, double pi);
EXPORT double GFZ8_iiiiiiij(double a1, double a2, double pi, double pj);
EXPORT double GFZ8_iiiiiijj(double a1, double a2, double pi, double pj);
EXPORT double GFZ8_iiiiiijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ8_iiiiijjj(double a1, double a2, double pi, double pj);
EXPORT double GFZ8_iiiiijjk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ8_iiiiijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ8_iiiijjjj(double a1, double a2, double pi, double pj);
EXPORT double GFZ8_iiiijjjk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ8_iiiijjkk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ8_iiiijjkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ8_iiiijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ8_iiijjjkk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFZ8_iiijjjkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ8_iiijjkkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ8_iiijjklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ8_iiijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ8_iijjkkll(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double GFZ8_iijjkklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ8_iijjklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFZ8_iijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double GFZ8_ijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
EXPORT double PFZ8_i(double a1, double a2, double pi);
EXPORT double PFZ8_ij(double a1, double a2, double pi, double pj);
EXPORT double PFZ8_ijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double PFZ8_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double PFZ8_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
EXPORT double PFZ8_ijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double PFZ8_ijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double PFZ8_ijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
EXPORT double GFG8_iiii(double a1, double a2, double pi);
EXPORT double GFG8_iiij(double a1, double a2, double pi, double pj);
EXPORT double GFG8_iijj(double a1, double a2, double pi, double pj);
EXPORT double GFG8_iijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double GFG8_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
EXPORT double PFG8_i(double a1, double a2, double pi);
EXPORT double PFG8_ij(double a1, double a2, double pi, double pj);
EXPORT double PFG8_ijk(double a1, double a2, double pi, double pj, double pk);
EXPORT double PFG8_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);

EXPORT double GFZ6_iiiiii(double a1, double pi);
EXPORT double GFZ6_iiiiij(double a1, double pi, double pj);
EXPORT double GFZ6_iiiijj(double a1, double pi, double pj);
EXPORT double GFZ6_iiiijk(double a1, double pi, double pj, double pk);
EXPORT double GFZ6_iiijjj(double a1, double pi, double pj);
EXPORT double GFZ6_iiijjk(double a1, double pi, double pj, double pk);
EXPORT double GFZ6_iiijkl(double a1, double pi, double pj, double pk, double pl);
EXPORT double GFZ6_iijjkk(double a1, double pi, double pj, double pk);
EXPORT double GFZ6_iijjkl(double a1, double pi, double pj, double pk, double pl);
EXPORT double GFZ6_iijklm(double a1, double pi, double pj, double pk, double pl, double pm);
EXPORT double GFZ6_ijklmn(double a1, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double PFZ6_i(double a1, double pi);
EXPORT double PFZ6_ij(double a1, double pi, double pj);
EXPORT double PFZ6_ijk(double a1, double pi, double pj, double pk);
EXPORT double PFZ6_ijkl(double a1, double pi, double pj, double pk, double pl);
EXPORT double PFZ6_ijklm(double a1, double pi, double pj, double pk, double pl, double pm);
EXPORT double PFZ6_ijklmn(double a1, double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double GFG6_iii(double a1, double pi);
EXPORT double GFG6_iij(double a1, double pi, double pj);
EXPORT double GFG6_ijk(double a1, double pi, double pj, double pk);
EXPORT double PFG6_i(double a1, double pi);
EXPORT double PFG6_ij(double a1, double pi, double pj);
EXPORT double PFG6_ijk(double a1, double pi, double pj, double pk);

EXPORT double GFZ4_iiii(double a1, double pi);
EXPORT double GFZ4_iiij(double a1, double pi, double pj);
EXPORT double GFZ4_iijj(double a1, double pi, double pj);
EXPORT double GFZ4_iijk(double a1, double pi, double pj, double pk);
EXPORT double GFZ4_ijkl(double a1, double pi, double pj, double pk, double pl);
EXPORT double PFZ4_i(double a1, double pi);
EXPORT double PFZ4_ij(double a1, double pi, double pj);
EXPORT double PFZ4_ijk(double a1, double pi, double pj, double pk);
EXPORT double PFZ4_ijkl(double a1, double pi, double pj, double pk, double pl);
EXPORT double GFG4_ii(double a1, double pi);
EXPORT double GFG4_ij(double a1, double pi, double pj);
EXPORT double PFG4_i(double a1, double pi);
EXPORT double PFG4_ij(double a1, double pi, double pj);

EXPORT double PFZ3_i(double pi);
EXPORT double PFZ3_ij(double pi, double pj);
EXPORT double PFZ3_ijk(double pi, double pj, double pk);
EXPORT double PFZ5_i(double pi);
EXPORT double PFZ5_ij(double pi, double pj);
EXPORT double PFZ5_ijk(double pi, double pj, double pk);
EXPORT double PFZ5_ijkl(double pi, double pj, double pk, double pl);
EXPORT double PFZ5_ijklm(double pi, double pj, double pk, double pl, double pm);
EXPORT double PFZ7_i(double pi);
EXPORT double PFZ7_ij(double pi, double pj);
EXPORT double PFZ7_ijk(double pi, double pj, double pk);
EXPORT double PFZ7_ijkl(double pi, double pj, double pk, double pl);
EXPORT double PFZ7_ijklm(double pi, double pj, double pk, double pl, double pm);
EXPORT double PFZ7_ijklmn(double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double PFZ7_ijklmno(double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double PFZ9_i(double pi);
EXPORT double PFZ9_ij(double pi, double pj);
EXPORT double PFZ9_ijk(double pi, double pj, double pk);
EXPORT double PFZ9_ijkl(double pi, double pj, double pk, double pl);
EXPORT double PFZ9_ijklm(double pi, double pj, double pk, double pl, double pm);
EXPORT double PFZ9_ijklmn(double pi, double pj, double pk, double pl, double pm, double pn);
EXPORT double PFZ9_ijklmno(double pi, double pj, double pk, double pl, double pm, double pn, double po);
EXPORT double PFZ9_ijklmnop(double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
EXPORT double PFZ9_ijklmnopq(double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq);
}
#endif