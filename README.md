# VOX's Blueprints
[![Convert Blueprint String to JSON](https://github.com/TTV-VOXindie/factorio-blueprint-book/actions/workflows/blueprint-string-to-json.yml/badge.svg?branch=main)](https://github.com/TTV-VOXindie/factorio-blueprint-book/actions/workflows/blueprint-string-to-json.yml)

> [!NOTE]  
> This file was autogenerated using a [template](/BlueprintStringToJson/BlueprintStringToJsonGitHubAction/Main%20README%20Template.md).

## Description

This is a repository meant for storing blueprints made by [VOXindie](https://www.twitch.tv/voxindie).

When the [blueprint string](Blueprint%20Files/BlueprintBook.txt) is updated, a [github action](.github/workflows/blueprint-string-to-json.yml) is run to automatically update files in the [Blueprint Files](Blueprint%20Files) folder.

The [github action](/.github/workflows/blueprint-string-to-json.yml) automatically decodes the [blueprint string](Blueprint%20Files/BlueprintBook.txt) into [JSON](Blueprint%20Files/BlueprintBook.json) and then breaks the [JSON](Blueprint%20Files/BlueprintBook.json) up into [separate files](Blueprint%20Files/JSON) for each nested blueprint book and blueprint found within.


## Blueprint String (V2)
````
0eNrlfV1vW8eS7V8R9HLnAlRm93e33+55GOA85SEHgwHuCIEkMw4RmhQoyucagf/7bJKORVu9uNcq0skM7kNgRBKL1VXV3fXVtX6/vl8+zx83i9X25/v1+rfrN7+//OTp+s3//f2Sf7D73dv508Nm8bhdrFfXb67/7Xm5/Hj1dLd93txt52+vPs6Xy/U/r+7ny+0P17Prp9Xd4812ffNus3i7+/D/u37j3Oz64/Wb5D/NrhcP69XhK54W71Z3y92fbD8+zkfCi+38/Uhgdfd+939P2/VqfvPL82Z19zC/3n1y9Xa+I/ZpNvnZxWa9ullvjj/miY89rB8f55tvPhiID+55PfpM/HQ7u56vtovtYn5Y7P5/Pv68en5/P9+MiwDLnF0/rp8WB0HvRRf2knOfdkx8Q8Mf8b162t6ttjcP6/f3i9Xddr15TSn/kPa0hh/SyOjbxWb+cPhtnu0IbDfr5c/381/vPizGT48f+WWx3M43lKr24n5cjtawk8HD+nlnNk7S2GfRYyKeVcPN/Wbx8FuXRvh02xNk+EJgu7lbPT2uN9ubnTW/lmE6kmGHUGS1WrFWE83M8JkZ12cmy4R8n1DRbDX0aNQXW1k9zTejYb3+uDti42sD7RBsAkHHEHQDQTEqLDonUOR49LKlAp26QPCW0Wp9j2KUeQOG65LAm6N4y9rG7JqwK/QC3cTWdFUnhRTJbISmKNIPAkVK/N7JR1Hor9Z7mVIElIJ2qvWJHB347++Wy5v5cpTDeP3cPK6Xc3wghb3UVvPFu1/v18/7O9anWRpue9+RtO+IJ74jzoKbJd/9mixvXyTZIlNC2q7atu0TafpeA/yEQScFhBScptV22nJqT6VB3ywJcBtkShlQitq2K10iSbj8M3OxhixQTBTFIlz+HI9VoMjx2OSdCtQaB+HKzsydEZ3MGzDe6AXeEsVb0M6lrhHHqB8maIVJJ4UUmYXLn1NkEShy4q/yaVTAaptMqfYppcHmCdTuLZ38zA3dazqJiYPWZdbbXIoK3Jbx/hn5DV1+9dgaSViPL4DWU9K2b1+GWd9ziB9DYIGEVG1uRUeze09xVGvrqlXfOA1kKQY93wGyL1lNqnXzL9krmYWBuWdzEEg2imJUUgsck0kgyTGphxRQtUVJCQzMLZKrzB0y4SYw1xjeyiAmEruWXJx+roAlFm/IfQBdlqDkFyhdliiQ5DRgSMOCZE/RE7EOZWLFVKzrJrKKbvmQIT2CQGKqqs3388wGm4ccWYweCKrqEbQDWYgadVIgC1GTaE99KkrwvGdl8uqoRSEZKJJK+Exy2RSSFJdt0DcUUG5zyp0ZmVOx6fUHZMVNKUC8ll2XO7X81mfMEEzDRRqCBKhOJY4m1VkVkpwO9MDAgayGGwyhQUa01Nig9Ml4W5jv0usAa4ybx6B55nw3ebv7lSlI737VPp+wC+ZmLgz9rzOU76Cwk04LGoFYukOKsxTvIE+G8h0WVrOF7F0914NJhdzVsTNsKJCzcE6v6bmKaHlxc7Y+GSXMdpUr4UeFZuFoKpE2y2dWaJJ86oU8rOKqXPeVKuo7Q/CBzNkrBYzX8uvy5514dPXN2lvCELjOYCCGlOqVsJtUqk8KTVIRhgi8oTUXva1qQLSqzZvww+ujf3+/h9GlqP37/agMTp2x3vXbhgabV9Jnee/97K6rkW3XZTvoZUAo7mCIXpAZBLEEiMRpKAJingyRCxZWtrklfUW3z7ZZ+ko27CnUWRX04qCHPXLqnun3jVHFcXfMzPTdHJ1Ck2supArlUeQzKDRJPvVQBao4Kr2GnmyE1Ose0JyjUvjwXDNkFNuqkFkbGqvgOpOhtQoqNTmlJ5JTavIKTU4RSU8K+4DWrGeFfUS0xLSwB2QM+wCypMciWFSq/QMyFvtHPGWL/SNhZT029yjXkfUmQo9SHVId3FNNcS6LDYW+nx/KSkuhTxxrSkzOLldpK2T5VGJzn7mGez02h2ZTlNjcUy1krhjiCrRFihfPk74JFkNojnkyBBZYAUpMThpIURoNWaUa4giUKCmGOALlSYoaR/QTQdXYY+hLJyTbxd3VzfzQTxVXZ4zze991SEvswr/x+/rVjmp42YTEXfWeQ2gGVawpItVZQnPIk6GqiIVVjHF+V9H5YFQu9pVs2FMo2VH1QmNAuY6mBOiB6qZzTSw4hn6CqCndiL5xrCkxObtcpSGR5VOJzQPVKOaaHpNgs5Fi88bxp/dmwS3Smvjqsf/KfLCEJoAnPxj6s5AC/KDE5JyB+EHpTuSU6gc9Ng8OrVlvTAwe0crG54u+c/aPF/x4uc98/y2aH9RX5KHPcjW+huyyvPd/dtfVyHbrs63HMVDcTu/tgmbgxNoiEKcz1BYxT4YABgsrGh9IdhVdDraZU1fJzrCn0JNVp9caA3pI65QuyEC1LHpXxX0IWFPmLwSq9dF7ZQIDuVyvzGBg+VQeFAaqE897PWaBZkOV5TNcc58/vaULbhGvTmMAZAwtXZgnQ0sXVoAyk4E0kKBMZSCVGgxzGRIap6DniUNGtMTZDKH0yeh1QsySwf6hqFT7B8uz2D/kyWL/UFiG2BwkO3zUexZDRbSUonmgGu98FHsXQ+uzppRGQuFYU2JydrlK7yLLZ1buK6qNzEfDEBJoNkp9JBSOP0NcgbZIEl9OARNMltAc8mQJLJACkhKTkwaSlN5FUqnJEEegREnS44iI8iRJjL1jPxGUjO2KoXXmBuzi7tRmvsb+0KNmjPO737VPS+zCv/H7cn/6kR6bQ3FnvbYIzSCLtUWgumwJzSFPhtoiFlYyxvk9RR8SOTPfwIgrw55CyY6s1xojynVkZTpipBrvfBZrjrGfICpKaSRS/Xu+KDE5udyi9C6yfCpPFCM3W6/oMQk0m6LURyI3qa8YxsChLcK/Vq8nTdAQmmCeDE1bUAFViclJA6lK7yKp1GqYmghH8uk9ixHlSapxfGKMvUFEFV7u6jP3CNjNNp+kz+7e94FXVdXjFyxmvaaI1S/WFIEom2WSIuKpGQIXKKzmbf5IV8mjxaCaQzPsI5S8aXp9MaLcTVMaISPVtOhbFvdfP+HVlHJITBxrylQIdrnKWAiOzzAoPZCRasELgx6nILMJg1ITiYnjT6+JoC0SBrGPq2+CYTD0cWGeDH1cWAHKeAjWQJT5EKxS9dxwpFKT4ai8/rx6O9+826zHf6doHzI7n9EE1s/bx+ftdZe6cMmIfPPemRcp8xsofi2PI8qxSznqlEme+R0WRMqG0KZwlA3OWuXkfJRye1wutqeP1crwyu+/osnX8z5dFSnze6+JlA1papZ0EI4jJ59HR0V+4bRrx9QXK0hcT2QnkOALR9V+CqbGfc3rmcg0D+vxl31Mmj4UjNJVcLx0wiCqfM6zlJt8GpOUhYn3QaTM7+kMKXc9DMMzf5bnwJzGx9Y7db4LLQpFlEKST2OWsrih21+7oY/aJJRzmDwpLX0T8KgU+iaaprOjLgpKZ1+OidcJxsuAhX2GWDsHKgyR8ApeGw0RdtQ7MrX3k0PYFyJiW4FayP8/aOF2dvj7N0dghLPr5d24I8af/cNd/biZX/30ftwfi9W78TcfxqUfbLS6WJov1bcy1PYCyzfsmLoosqH/S5ANv6DkScKez5evPhn+XKBCOyyeoYA9CdLH+aPu++EmfqMT9k6jyxnuhFLonKw7oZVyaVi/einQwu+JD3gmMKNzFwBU/JOhADXgwz8XClCDULwwFKABPTGfRgQ0YB7miwMD5osDA+bzgAGncBCpRxnOSUCI4WKAj9STDOckUEX1Fuh3V1Cz26MkNiGDMnE0+apwx4mt6dy5STjAE9xJIKrBibdy+HQa+I9gzHFRP0NSwhkNUSHJccknPfzEeRKyTgrZSbkUaGmoF8MbjXHW75axPN6YBAW0Q6wacADjJA7gmbikKv5fmsD/o3SZsS5Hs2h+1rqNJhZswDiJDXgukmoUp464E5achhOrr+IleS5MoJswQhkn8ASc7yjEFGatTuAE0iwDXSUv3kl9KiKcgWsnNY7gEaN+asdJlECaFJJgvjRebSqXAuRN9dLItwZswDSJDWgHCza8xgCiyv7SkL45XArkVgIETCIeoB3kNudzcIHzuUiA3ELrOZC32QoI2BQey3AxhF/q9YVzCsSvBR0wnQEO6JwCF1yi6AN0LZl6bOGiJLas39F5EhiQ4I4TW9W5S5MogUQ8SsmORwt0J44n6rGFk7DBq1eiWm6tUuzNcWnwk/IkhiBNCthJzRcD0T6ERAAMo5ZLwX7Xi0GR13YBYG8DemCdBA88E21bfVCRsVLHkHmMeepuyGQ3ddHCBYC9W7wYGndLxigXrr3tprZ2J5W1y+GRtyJemH05VmOkW/shfjpA2PXfSzVDhF7Phx10E7YvwA66Eyapww6ewHXfpwxGOaYp1EH6NIeCNFwyZRpS8FKo7G7IF4Oed0O5NMS7gjI4gd79FcYg1cXRH0ZrGGAIBebcxRHsnaEmjiQmFcWbCiV4Bqg7hx6YRcHlcxDsp8ADLSjv2Qwi2DQ22+WA7TkQQeckaHtnqZFD8DqpSM5NLPZB7UZydjBBF0XhJUO1F6pXqpWT0jMUy9s0nCBT9iUl2NQ+sUngQII5TnjBSRVkbsFBCuBJRg1eFTTDYHCrLgAZ+IUvP40YSNOCKH7ixCoXzgUDTJPLM6DNQlQ3cWIbWF40XA1wfdECMwsXKF8KYIXRcH4TWH88MbhCuX82TAH88UcDXGE1EIMrlFpoqXHMCszfcEzZjPL3hb/A8adPynEQZk6cYuvOBvZLkyKT2mlJlerPqrHIFHQzVqUi2p+bRPsjwi5OdFkCHeeWm5X5USyfCs4Gy6eluRYCHmrttZGDsDN0TkHLpgrhDp9WfgIMkLxlAXNam228NAKgmzy4uDGEURNfMfRIQQUXreeWk2EJqpMxiQbIMEeKL0nRV7wcLKBrIqcWHyueDwzoJ4+FovdKOYTSaIUHdOl1keBQY5t5X6fQAWm2EVJlFQeou3Ip0D8sSYPLBZcntlGh5WVbFbWn3ENhfLbDR/Ch3E6gAvJ3HxSn4Y08lmcz1lS7kki7guJJSbRBvWP7CmyWywZJVK2pv9yMPSHsa8q7iuDMx+F2AjGQZx5psEX1UgMSTcaiaE8In2vLowT60JXN8hwkTwMH8sSgOJUGXle5p4OGawkN7x+UCdKOQ4wYDPdPmQYR5O6fPnqCYVghFpnSzMupVMENTJMiU4DNWZWKw6KRGqR3tKTopNCfW66T3tJyfDop9Cf5tGSF6zRAIBMEc0AeztCvBS2bKq47fFr5CUhA0oVoZ8ABRlF8hjZfrOAmcciJzxv6saCCvdTxS8rQqy+kgIJ9kJgjxac9s60qHCBDlOTU4mMhU/QWH6tMowNKobUfAFDuGHAE35/87nXfyyNwlWAotyDUlyBOLfHuXJzANLk8g88Fl2d8jttXcd6HVDu7Cf0UyjGgIOXvIHEa2n6xPK2vck8KIQ6zENztpVAHsQabeM0CkUbrE92uFPbphbKLK0cp9LGuoiE1AHWolPEnN0VU889IpNEYqvdFmj4bVbmdgCjkh0BAcVruJChOaVwWN5MnGiZmoWkrUsXfcxN+DBV/j4boJPUKCudiE6YpkSVpeBanUkPFH4tMqfizKhVHaCE1SEO0SNEp4T+7XGmQFonOpoT/JJ/ZMkzLT+MOMuO0uMFQlpo/tGyt5u+54VBZHaoFbDtrY7VI8VkGa52HORhF8Rlq/lDBRRuvRc4mUx9kAQVr5X5SfEUbsiUjDjJESU4tPhbEMTT4WJ4AHaT9DYQFVgy+VZgGHuR8l0nIQdo3gLhw+htfuLwqzvj1Z6MLukn1VUNmGC9QvhkmQQT5IxKu0HIjhGmYQPJonIQI5LczhOMbDMQIoEAiviHB3vSOYQ+x94LCHwlwp2MD+jSNDcidYQDHT+8YxiJTOoZZleqvRrDIFCxAL2MBcmctwLJzSqyUOdYUGEB2uUGJlUg+o0KT5NPQL+zzNDYgE92QeH6Gri4P0QurxKGMDkjesn3bdlK/MCk+Z8nTIgU7L3HIic8Z+rSggp3UNMzKMKlOBlBwlpgjxVekUIlccZWIkpxafCxkit7iYyGr8Xprlq+IljeWXUsHi/lQi5uF0m1xDF7HY/YF8R1FP6l9OhOFL02K0uBzweWJrVpoedVYce1p91BQH7Vbxv/a7ZkoeW7SNINhICMU6HFpXau7dkVRdpXGk6IIXr1m+yoMlvsGijRa6649KRyqzrsi4SxUf3smRJ6b3BRBfQ+MRFqspdKuFOLBFsCo92B4y4L1Z7mTkDij0jUcOPjGqF9NYZiGciNC9cbxZ7iCGuJPvIJCH3Qr6lcQFpnSNcyqVEdexiKrSqhOqrSJaEN9NSTloTApuiSF/9xyk/JQmOVTCv9JPg2ZYWjXSeoZDhxgZ7L0dSHLpirtDp9WfQ5VaAVk21LPMCm+bOgZhgqmntS7qIkvG/q0oIKz1DjMylB9pwUUnJMUqpPik94JsyvW4n+SU4OPhU3R4mMhqynGB8PBd+Ytfw6+Yu72OIZi8L0QMlPRSy4BQjOJQ1pCH3Cr6C1beHkGnwsuT0U7BMsrRqyirqXUQ2Q2ml8EyZhi6AvG8rS+GD7JffUj96HLfTXkBqAGq1Ov2b4Kq/XJcFcK+/xC28WVoxT6sWU15AagDqthDhgWqZqDRiLNVkijrkjLZ6Pqp2yq4T0LFqflToLiVLqGAzVxKDS9azggzDyp6h8Cx5/hCgqIP/UKAmQMVxAUmdI1zKpUz0BjkSlVf1al4pwwpAblsTAnujhI4X/gaCqPhVk+pfCf5NPQEYbsOg5Sz3CgRhZFS90/QMhMqe4fAsehOicsAOaknmFWfIaeYahgre5Pis9S94cKdlLjMClDp77TAgrWSv6s+KS3wuyKtfif5NTiY0FTtPhY0GoMoLwZweAafKuEaIkvskLpkzFA88Ll6Y+C8fJEyAa0PMsNAddnQeGFC5RvBrBCwxQJvELLjYBWGFSgOLDC4AzbGa1QeATvJ3UYlK7hQI2SiUHvGg4V8adA94TC8afPmg8F8SfOmg+tT0bvGsYiU7qGSZVG/eUIFFlUwHtIlUbxBQlQQwxKrESKLio0yeUmJVYi+cwKTZJPQ88wtOso9QwHahZNjIa+LmjZSYLwCdRgm5jkHG7ftpPUM0yKL1nytEjBSQLxYcVn6NPCCpYah1kZFtXJAAqWEHxY8TUpVOJWTD1gd03jNFt8LGSK2eJjIavJemtWHBCtaCy7tk7V4FBEmyXXbXGMWcf3CQ3xnTU/Kbo+Gb1lC4vS4HPB5YmtWmB5alE9n9TuvqC+KzSOGu7WhWIxTH2A8rQAuUOBHpfWtbprVxRtb+ix5Fnyri8KFegdqdBw32CRZmvdtSeFQ9V5VyQcpRD7UjC8CcY6VN8EI5E2a6m0K4X82Q66o9ViNbxngfqrljsJibMqXcORGiUTq+Fq8oi/qPDnOP70Kyg6xJ96BYU+GcMVBEWmdA2zKtWh5qDI2qDwx6m0OfGq7KuhKY+FSdE1Jfxnl6s8Fmb5VMJ/lk9DZhjadZN6hiM1iyY2Q18XtuwmcUgNtkmDCvfQt+00SD3DnPjSYOgZRgpO1LN6F0XxGfq0kILTIDUOszJU32khBReJOVJ80lthdsVS/E9y6iw+FjJFZ/CxoNU446PhGF97mrvgCwReyRn8roh41sstMSBa4pCWCMjo7Vp4eQZ/Cy5PbNNCy2u2ML1rJYcEDIpLkzf0A0NZeutb4T7n+8QCiiWTN+QDoOZkoHigOm99J9yXwD6fgGLJZAGQx7ozzP7C4lRzzkic1Ria98V5wpgMb1egKIPl/kGiDEqHcKQmDKWgdwjHjPhTKvwxcfwZrpyE+FOvnNInY7hyoMiUDmFWpXq2GYtMqfCTKlVR5YEaovIwmBRdlEJ9crnKw2CWTynUJ/k0dH9Bu45Sf3CkRhQlS40fWrZW44+J41CdCwZsO0n9waT4kqE/GCpYq/GT4rPU+KGCk9QkzMpQfZOFFCyV91nxSe+C2RVrsT7JqcXHQqaYLT4WspqsPwCOVNdTUl7Si5Rfts3z6u18826zHv+d4vrQ67D9+Lj73Pp5+/i8ve5S5z0wL/LN3zhBpMy7aPGYcpeWIStAcll1LqkOlZQNlRnQU5IKv72ytv7jIfePy8W2e7SUP2g2hqLXeS0cr/zVVEUp8PuriZSTTvmVNGKXsqWEUznSFieP1GEl7O3F5asMSaGpUzzDlOf54sErNAu4KJK21H7Q0Wt5mw/PMeVtfp7kLDGmJJ1dysR98fBS5u+Lp5fwRN+Jx5dlQD9J+qjbYNpj8rLL1HQnMoHGntR0tzENnBBedtfDevW0vVttbx7W7+8Xq7vt+lTm7tDrNH5mu1kvf76f/3r3YTF+YPyrXxbLcSfsMqy/Xz8t3q3ulruffhbYYjt/f330leMv92SeV9uR+GwML97Od1/z6bYviGjxctuxyhYrqLEkO7mslLPs5LKUi+4+N2RluivKcqm7ohzlPAy6+9w4yjriDEtZd1BZafB3ZREpR92pJqWRZKea5TnLri9LuTA3/wDEELskDe1GiRoVl5WpBU4j7Qz+KUva6V41S9rrri9L2uCtsqSjwWEHZ312lloxt6GdwYdlRSD4sEUkXQ2eNymQpnveJNdKu0YTSTvRM2x/qWuYveENFXK4sw+m2IBzNPNRVwgl2i9G8brf7Ww5Lzbr1c16M9dknfj7Lzkk4ywamINiyH+CGG5nh4+8ub5fPs8fN4vVzhSWd6NNjD/7h7v6aTufL69+ej/ayGL1bvzdh/G7D1qqLpbmS/WtDHWXB3gh/Jrqzf16/dsR6R8f94KYX/39x/Gni52s+iv6sNhsn8efvOhm/xc3f78+/saZ8Mkfjz7ppU/+7eiTQfrkP44+GXfyuRuV/GH+8+cfDYxch903fhHoz3uBvjn6yUGAL3ocf/d2/vSwWTwe7On6356Xy49XT3fb583ddv726uN8uVz/82q3/38YOX5a3T3ebNc37zaLt1+s82Cb/tNJHX1tdV+XD6e0hC32pIq+PVcfH+ebbz4YiA/uef1WN/s9vZgfFvvNBhfH7XQfY4lzFvpDneU8DOri1yEPQKQtDvHoHp9CmxX1JKMoIBEMQeWxEcWhBE/IEHTKrEKq19xJQAUURX3clGMCTqePnvIUXXUMVc+4naENCWxaZwEnAKSK0HDFmUtV8CIoiobhawAOVB+9hoBxxZugT8T4VCL0UKdmsftOwouvwOOJ7/Az32apOzLcG6bfMlvPgMEWKbriYHYAKm54ro/Qnw3VYYR5q2m8nbSq1J8urm8kCHMpU4I4itqW7ANbKq3eHC6t8qabQ89VpkNzPCrQUByPRXAaOMzNKlDkoEENFRzmbDFMessUXfHZNxgVacjJozF5Oik0kVHp+07c2CWBYubGI8knFRpnVGRKaMpS1c68/tirZnNDatdFSMPMDV0fIQ02V6QCd2e8m8av6r/50wudXIOYHrlw3WFB29qt3/qv70fUVGQIVmCfqc0d6Wm9HayrdFWubyrUNFD17ArschETRt1sT1bAOMn6jZJq4QrIXvAhOCaDkm3hmFQmiVL4YhS6WoZMdknq7/C4erze8P2a4S5h8U04sHLDHFGwg4vhxTfawkUB6qBMpigwHZzJFENCGCSXip4SdiC5VMSksOsmzoq+HRyVLiyG/UDlC4u6H/rrNuwHpFQLJBrSatUjdgeyHlV/pO1A1qOKKE6uT0UJ1h2FoFOV8euOAvqpSrhOcqm81ya5VAJ2RyGEVAXcyVFIJk0P1h2VuWx6COKo1GVTC4hdS2+G4B1t42YIPNA+lgazcVbTlLHspNXowYYDWZRmiDZAFqWp0UY3Q+QGIy6tS52BJG0Xos+c78ZsbnC2lEDvqw6Jh114OH5d7X+dofBIpfzcoJceXeYoi8VHpFRL+RGYrBsMBUhktG4otgRB1wbywdxC7OvfsNcKYluvSjqQInFuEDdu65ORonrqiZVzyshcVzmaUmBP8hkVmiSfUmxfuGaKrNCsHE1DIEOlO53TR+64ylEWx70Dk7fMdoNb2htmucM97aUonzMer4zcIY3HG+L9htasz5r2A6Ilzpr2rk+m2JwZP7y+Xfbuha8zV/ruhTrKLZ78rr3XtLvKxu9r/e/TC5iucY1UelTkB46yWMQEag2GMiY022CIhaDdhmhzZ/pGUA4GV1PXAIJhv6GeMgOkm0dNZSqkm+93zFElf3e8sOk7PSho6Z5ruYzKjHeSTwnijeVTmQLnuW4/Ce/Nc/1+UW8m81yDaNTbyTzZIio2lAGTt4yCg1s6GprK4J6OTenr5IyHGgfXNONJenrag7yWS3p+2kdES0xQe0DGsDeofKVLhr0ROcrq3gBLt+wNqFrL3oC61XMBHuVWst5a6VFqJYtdyr6fO8pKDsBTHYcuK42WPnM0lRwAy6fSbMnyqeQAPNXu5rLScOkzR1OP/j2XLjXMcfNcurSIQ3iByVtg3eCWtsC6wT1dlBwAaTxFab8kjacYYhOUmCmG2ATlZYoam/QTT6Ua8wqlE+bt4vzSZn7oh3kqels8+V37/MUupBy/r9vc76oh+ufyiVUvinoun1jFqihQa7WkApDZVkNdFNrt8WQ2Ka/QM4JDUmnm+7Clrhr2G0quVL1UGlBupYrtzqGfPKpSDoDqVXRN6dEMA0dTygGQfCptmiyfUg6gcW/+JMz3gaNpiHC4fGnTe9QCly9tRXx72jd5C/Ib3NLNgvg+oCeZUg6AMh4/KD2bnPH4Qc8FBIfWrLdrBo9oRfFMDH0yyfgW1Xeul9G/GH2Lme8/HvRDNr5J7X7X3m/aXWXj95X+9+n10UDlE/1gAMD2HGWxPgrU6gz1UWi2zhAUQbtVceLaKSM4OLMzn0PXAAxYcQE91DVgxQX4iFydmgHIKIMzAtUP6p0yOyNEjqYyPoPlU5mgQfLplRkagepB9F6ZohEiR1NvZwvcq3uvt7MF7t29V2dpgMkJhnY2uKW9oZ0N7mmvTNRgjUeZqcEaj2GqBkhwecM4gJARLTFnHUqfjGFvULlLHwx7I3OU1b0Blm7ZG1C1lr0BdWvIBRRES+/lDBXREhunQzd55KOUA6D6Gn1UejpD5WhKOQCST6Wnk+VTygFQLXQ+Kj2doXI0DdE/lS/10RC5VI6y+EYNmbwlFYC2dLIEK2hPJykHwBlPUno6SeNJhtikoTUbQEVRXiapoKL9YYfq8393vMZv3//v4vxUZr72w7xUjHmF7nft8xe7kHL8vtj/PkP037ipVwacq4Gbe6WClPbVmi2pAGS22QJzjew2B2NeoWcEh6TSzLf+0LNs2G8ouZL1emlEuZUs9k7HfvIoKzmASPU1+qz0dEbP0ZTAfDk+i9LTSfJZJGRfqoXOFwnZ13M09QgncvnSonevRS5fys8aqKdM3gQAh7a0CfIN7emi5ABY41F6OknjqYYZm3AoogG0FOVlqjgeMAIywebPxNi5Xnb+BfAtarT5Mv3v2ftM8BqrhiGbXB6xGiDluTxiFeuiSJ2WuZvQXA3BELTXNtj8mK4BnHBiDZhuCGTYN71GitCPfRP7pfuA1L4pEz04RHnflJEeMXM0lZkeLJ/KUA+WT2WqB4ea7Zsy1oOD9w6D3sMWqfxvOGoumMZRSZDrOA2qEgaxqa2/B8JgaGpDezwMhqY2tMnDoEz74KwpDMq4D9aayndCTw9HHQSXxzgPwpACDWo3KI0FImVnwzgnKPsL4JJ3zwShwSCIPEcCligL0M7BpQvgvvelkG3o7ATP5TuhlAdhwkERKTcNC+oEVPmfjjwWLHMVSLl45f508pF3DKoAN0wTAKyDDxdDPQ7+O4L9Bv+9wH6D0iEhUi7/k8Cag/9eeMJB6MfQ8JSD0J2BUSC7bpEA3pBFnv0FkIr7PIfvhNscQrwA6m+fZx1PmIPoDUJ7RxGlUfSLleTZCivcJdZMtxF5IgtQEBqUaYgilGn83nibj8u7LYKapCH8MBHPwvnd3G8WD791aQRwqB/1w1CyzH8ddqkKhmiXoybBYMiJvBZfZBy8yERE9SROazjqApJ8878ApvW/g8YncWJ/3Mw1lNiv0UwvAVbq/xKw0i8HliTs+Xz56pPhfx726AQNd4IRutPVneAkXQoF9TsCj54Jq1ovjWDaLoDT6oZLw6A6Z0IEPY0teilEVRuq6GkcUQM2az4NKmrAZs2nsUXPwDo9C1U0XxxVNJ+HKvoVHivxdM+GzjpNmGoFdwpYKzWk1DkFrdWr90O/EUeoMk2cCJ6q1kZJbFnnDvb1KNyRLTgMSQkD2jfxvg6fTqOGEoxRaw3UnpAAjINXSHJc8leIn3BVhCSTn/AtDNNDQedLyBcDMo5uVvuQs+VS2M2hXgC72QAeCoRngAsFC4simkLGahg12tysdVuGor8AdrIFPJTqOYvRhqQ8TVidkHDKyusJ8WbxAj0XY9RNGag66uoEhvgoxDQuvDs/W3lLNLET0iDeV30q4n5y7aTGESyq1090oKlkuGeQBOOlEL5TujSkdsqXwgxP5dLg3KleAIU8tUsjfOfBhHVthQ6VsMKzN+FlWxFDsyS3eA7qeD4NGGpH8c75HLzsfBoc1ICXnU+jgkpI49Nwo82GOz6N2zgo0TDVjVikmD2L8KGcf9C1IOGNj5s4EajpoS5KYks6d+BMKFnhjtNAUeJYbsFVdFjKBGQowRi11joo0TC11irF7ByXBh8qTQKJ0qSA6VXdhwJP46seqoN38dUYqlcUIwIwnCqO2e2OF6j6A2skQD1cBwJs4gPq7sKaMVKv3YTJGFSNanX9V/HN8Liaanq2IIhSfcQtGgNtKJ22m3fcnQ3YkniZ9tVpyAcDQ22GuL1OIotqcXvtJyziAV+z/4iwqRnidhns0YZ53icaRn7DFPQofc5DLEjD9YPmPBtmg6I5rYPy9o0bHzwYau7DNIooUXbnRhEP4rXj+uNyB2VSISk5/QZq03ChRP2dE5ylAo8U65SZBO1ykKFZXLKKrNu3Fae8YSNXKyFWk6s1DCNolwYJdQNkegollAifucniXoryHTda3Du1K8pNoYbS1z9E4wxK5NsujRbqJs8JsTJPaiIrMTC56qK2qwHtapV5csFNCae5BQcp6icZDQaPC0J2GjwuaIdBd7mcm4b/pGlBGE1xBJsL5yJ7psnlGaCm4fLEEYRoeZZGLhIu0oIuTeJFyhcGAIw0XBhQu9GQFIbqjXKPL1hhMmx1uMJsIAZXqLekuDCN1UkEQ4HDe9VHPDsIcajMtnWRa15VW9onUTqJcIgTXdKbfqFqkwJLyIpOf8SPVavAEbLyU+AI2TWr98UkWCcRXHHLzQqIDblcy4hNx0G9WgZuOg7rlcP1xAeZNwN7Onz6+AlkT/IGBiCrhuQvPCuy1A7Miq8aOESnBTVs00VNF0XqDCaXXZzqgEzCdzLMkSsOUoQVLofj6ZrIqcX/CucjefpJn6QY/C+I0WrE83TpdeHhUIybeV+n4DxpthEabB1EF6oPd2vA5YSSrHo7F15esNVJe1o51KpnO/wOHwDwqZoRLlNQnfz1ygEnV8N8WschJ9diLLt2hR13hcLTwq7q/Vum0Dz52w0Zrzp18+Wi6wlhX3beVSBnPnarpk6Yvukmd0vz6oXXl2gLxiJsTwifa8ajBPpYs83woAWrz3JXQXHqbcYOVYib0mjsCveAUUfAcXUa0pPgj4NvGdS7qQ8xMigNx5zoFDDPNKHaYzBPgj9SdPqcdKRaPyhvhFn5SSkDcs3iRGdkLspLYXa5UsqAW64FmdNxqEEWnE7HwQY56cGw42B1nJYz4HB1+Oq+O3n8OEMrMjwrnNSMzIrP0DIGTwvqob2Loi6kvmRy2V594wUUzD2rz9qKvfSImF2xljMgObX4X8i+vcX/qufDcn6h1aZROemJLAhhyBtTBX4AUNljkBR8H5rBi/NavDsXoDNNiTLouQIoyiA+JUbLM6YJuhqpYR+17dQcfLqdAOrkL1gO+csC3uk56C/5lb5jxBSHUUztdgLuk7uCkXot+es2jfXJz+5A9hut6YKuSPcJk7yLlGchdKNlH9WcNhBp9MYQv894ONhB6G+XaBl/gfQXLQMwoP70dmaPxsxEpZ3Zcyhkhg4DjwbNSB0GnkM0i+r1FKaAP4mhXZzokuGaghOEpKFinOgMHQZQtUl5pczKTxotRq5ZHC6GzEV5q8wuVxowRi7X0JnmnQrjyZPmpoxl6cmyJwdmaYPGuDlXWR01BuwpG5qaPYHjyQz0IsVnGTgG0UG1kWOkLqTWZnbZ6qMyoGCtvYBccZGeMfsLwnm6JnJq8L+gfReL/wWH3xn8L4S+V/R0gY/TyJ2cXzOJ2Unf8XB5+vsxuLwqvmH2Z8Nzuq/UR8A7GjrUPIkcKd8aYPWWWwNCRxqyzFi9WT02AZ1i2OpwhdVALJ6PtPmFVpoG2iTiIhJ5UQfV9HkaVJPgj0RxFME1/RngmlEUnd7ZjFWrgGqyotNfwGDVKmCarPwUME1uzWFQ7wuAQ+mUGCtxrHmFJrlcw2QLT4KHGjLHPnOkkxRiXRBM0+HTZwpNk7yBgT0Z8sIe4ppKfc2k+JQi/9RpcQyMyXDI6cJJzc3ssoPqgPQVTA3Md1lccZJCLHLFWSJKcmrxv5B9O4v/BU3R4H8VBIk4GMuppQN0fijazULpllOPsSdpvivi24s+VPt0JrpkmhSl3jaGl5eMNdWeWg4V7lEtcfyv3k5ATHI+BhCnYcyF50B+vWHOheeQc4/L/FpptivtvKsfnpR2GNQruC/uYOhfhuYbvLWa2pPCoTC9K0rOQvW3Z2JBuskNE9T3zkikyVqa7UrBH2yhxtsz8R/95EkeLPcVFKfe3ezbNMgjEUJTM3oUaMcvU7sRCGV0An+Bw9+M4vUU3BSyHxFCk6IzXFNtGslvmj9WdPrADKxa5SE0Kz8lbcCuuYm4T31zScpDaHK5SUkbkMtNlvwyB0+bLMgWA0daegftOUDkJOUNAgdPm1QQC2RPht5meFYkqbeZFZ+hnwyeFtQcARc1XWSpwZlcdlbfmgEFc/MCsrhi6R00u2Ipb8ByavG/kH1ng/+FTVH3vwLCrMp6uiAg0KpiTBcE35lg/TkmjbkfHxRxQE3ow54V/bUZFGXR0wVYlNGIF9UVZTqEW6N+Yi59cYrQF0ichjfQgWqrCsWQPQieI12t8FGnpF39LBbXl3ZTr+C+uKshhw3NtxryBdB+qzVf0BXpPmNSd5HyKNJ+tFzVvDYSabQCS3UZT5/toL/rquFNDtaf4b7C+tO7mwNCIKxKd3OgpjoFQ5dBQJiDUpdBoCZEhaZeT4A1pbuZFF0zXFNItVKXASs6vcsAq1Z5DM3KT0kbsGsW56chc1EeQ3PLjYOSNuCWGwdDd1rgICYHQ/YgcCCTg/QWOlBzoeIg5Q1C5Iiq89MCgD819DYHiKUq9Taz4jP0GaDTImp9BqQunNTgTC7bqW/NgIK1FgN2xdJbaHbFUt6A5dTifyH7dhb/C8IFG/yvhGgZ0gUZ0RJflYVu90j0+qNnuDyvvyaDy/Pio2e0PEuemepSi97QpRYyR1q+NcDqLbcG1K4FLBmqV4XyQytshq2OVigMAPCT+zPoXTShIFpKd3OgxvVEwzz/UBF/CoZSqBx/4lz/0PqsKd3NrOj07masWgVEiRWd/goGqjYOSozFyY+q5GdtzVG9L/rmQlXym7jcqNAkl2uYgBGoDq4YLZnjypEuUohFDfyJ3JN9fPr0icp54b49JUteGJ0VSeptJsWXDNgY8LRIEpoSqYskNTizy06qAwIULCEpsSsuUohFrrhKRElOLf4Xsu9s8b+QKWaD/9UQLW8sp7ZOJeJQ+5sl1y2nxqz7ZXFAfEfNh4quT8aQB4ai1NvG8PKKsTTbVcu+wr0rFI6qyX3ViLlhJE7DxItAtVXFYph4EQeOtLOWZrvSrvtNEEepp/5Ut1i8eAUDcRdD/zI0X7Ub4OWu60nhUJjeFSVHKcS+FAxvnuGGKeqbZyTSYi3NdqUQP9tBf9cVw5scrD/DfQXFWfXu5ugQLaW7OVLjeqIwH+ALfx7xFxT+PMefej2FPmtKdzMrOsM1BVVbFP5I0elDM7BqlcfQpPyakjYg18xX8uspc2nKY2h2uUragF2uIb8cqQ6u2AzZg+g50tJb6EgN/IlNyhtEzxFVoTWQPRl6m9FZkQapt5kTXxoM/WTotEjULAEXJV2kQWpwZpetvjXrKzhxMwOyuGLpLTS7YilvwHJq8L+wfVv8L2SKzuB/BURLTxfEiGgZ0wUxvvaOdzEpiEeTEwfURMCu/tIMi1FPFWAxZlt43xfjPuOCgs3kRFwNJErD6+dItVMlZ8gaRKqdKsnDBU4a7CGBggLa5FVMZyBqb8hbQ7P1hhwBtFtvzRH0xbnPkKDoOHk1j43EmY0hfZ/pgvVveH+D9Wa5m6De9E7mCFoJUlA6mSM1xSkZOgpiRvwpHQUxc/yp11Hps6Z0MrOiM1xLULVKRwErOr2jAKtWefjMyk9KEXBrjuK8NGAuUXn4TC43SikCcrkvu+N59Xa+ebdZj/9O3uCvG8Zm19uPjwfWHp+3193vsqQOqK63FKWH0JEaDJWiljTIHFF1gBoyMENjMzw8otTYTIrP0mQAjw+tyYDURZK6m9llqw/NgIK1/gJ2xdJDaHbFWtKA5NTikCH7ThaHDJpiE47ML9QO3RCfz8j18xYdkgo6wB+0qeasZGg9YCnzQU8QKQvjz0XKhvQC6BBJQidC/NoepnaBpS+BXH/Rea5o/fz2ynD9fS6PGt4el4tt92gpf9BsBEWhFyFrEi38/mpQCl3vRhhC0ESe+f1VRcqR0NyL81QZkpb6EGdnlrkEsXLKEx4oiGeY0IPgxIO3MBvvxd9idp5lGAE8ci3DCOD5dTyMAC9WOmaqkLoTz0QFvCBPLl3YU+IJIDQrOPHYOupdmHbBvOyDWfAOWM5NzmM7ZhwH2EftDQ/r1dP2brW9eVi/v1+s7rbrU5m0A/3xM9vNevnz/fzXuw+L8QPjX/2yWI67YZc9/f36afFudbfc/fQPTrbz99dHXzn+ck/mebUdic9GTt/Od1/z6bZrewLSwh+cJmpEXGp6i1EC7VRJGIcQjuXZpRVlWuyKk+wos5QNLmjjKBtcUJKy3ofESqPJPHOU88Bfj0Wk7HSXt3GUvUyZ5Vl3TFnKUXamWcrCXeqgoH2XdNZJs1wb5maxpC11Z1IgzeBVU93qWQF+CCJpp3NNytp5netEDTrMzlKG5g4QZwDiYrkWdmMUSWeDB04KRNiNReS66lyzpJvoeLa/1PPMwngJ1zRRCNMmXBVJe1PUwwUP2RuQJpHTnI+aTSiD+CLk1x2FZ1vH03Y+X948Lu+2c81IkqU0+noFkQg581GjC7eD3HeU2GKzXt2sN6K4CpNECS9Md4lUUQwRiiH/CWK4nR0+8ub6fvk8f9wsVjvTWN6NNjL+7B/u6qed7V399H60mcXq3fi7D+N3H7RUXSzNl+pbGeoupfRC+DXVm/v1+rcj0j+NHF79/cfxJ4udnPqr+bDYbJ/Hn7zoZf8XN3+/Pv62mfDJH48+6aVP/u3ok8H8ybiTzd2o4A/znz//aLicTF+0dEKoHRP5crSclOm3V9bj43zz6qOe+Oihqny/WTz8NinUkychFqpjhDowQv33H/9j/PPF/H89Xf3tj795Gn//dv70sFk8Hrbq9f+5elgvl4ede7X+5eoLuaer93dv51f3H6/+IPTDf67+c/Uv238utg+//rD98K9//Px/2/bCv19/YyW8dX36L11nwuE=
````

# Factorio Image Assets

All [Factorio image assets](Factorio%20Image%20Assets) are subject to the terms of service found [here](https://factorio.com/terms-of-service).