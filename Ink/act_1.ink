INCLUDE Ink/act_2.ink
INCLUDE Ink/act_3.ink
INCLUDE Ink/act_4.ink
INCLUDE Ink/act_5.ink
INCLUDE Ink/act_6.ink
INCLUDE Ink/act_7.ink

VAR currentScene = 0
VAR currentStitch = 0

== Scene_1 ==
	~ currentScene = 1
	>> disclaimer DISCLAIMER_1
	>> clear_text
	>> disclaimer DISCLAIMER_2
	>> clear_text
	>> disclaimer DISCLAIMER_3
	>> clear_text
	ACT_1_TITLE # title
	>> ost_on agony
	>> clear_text
	-> stitch_1
= stitch_1
	~ currentStitch = 1
	ACT_1_1.1
	ACT_1_1.2
	ACT_1_1.3
	ACT_1_1.4
	ACT_1_1.5
	ACT_1_1.6
	ACT_1_1.7
	ACT_1_1.8
	ACT_1_1.9
	ACT_1_1.10
	>> clear_text
	-> stitch_2
= stitch_2
	~ currentStitch = 2
	ACT_1_2.1
	ACT_1_2.2
	ACT_1_2.3
	ACT_1_2.4
	ACT_1_2.5
	ACT_1_2.6
	ACT_1_2.7
	>> clear_text
	>> sprite ronan army_smile middle
	-> stitch_3
= stitch_3
	~ currentStitch = 3
	ACT_1_3.1
	>> clear_text
	-> stitch_4
= stitch_4
	~ currentStitch = 4
	ACT_1_4.1
	ACT_1_4.2
	ACT_1_4.3
	>> clear_text
	-> stitch_5
= stitch_5
	~ currentStitch = 5
	ACT_1_5.1
	ACT_1_5.2
	ACT_1_5.3
	ACT_1_5.4
	ACT_1_5.5
	ACT_1_5.6
	ACT_1_5.7
	ACT_1_5.8
	ACT_1_5.9
	ACT_1_5.10
	>> clear_text
	>> sprite ronan army_tired middle
	>> sprite ronan army_smile middle
	-> stitch_6
= stitch_6
	~ currentStitch = 6
	ACT_1_6.1
	ACT_1_6.2
	ACT_1_6.3
	ACT_1_6.4
	ACT_1_6.5
	ACT_1_6.6
	ACT_1_6.7
	ACT_1_6.8
	ACT_1_6.9
	>> clear_text
	-> stitch_7
= stitch_7
	~ currentStitch = 7
	ACT_1_7.1
	ACT_1_7.2
	ACT_1_7.3
	ACT_1_7.4
	ACT_1_7.5
	ACT_1_7.6
	ACT_1_7.7
	>> clear_text
	-> stitch_8
= stitch_8
	~ currentStitch = 8
	ACT_1_8.1
	ACT_1_8.2
	ACT_1_8.3
	ACT_1_8.4
	ACT_1_8.5
	>> clear_text
	-> stitch_9
= stitch_9
	~ currentStitch = 9
	ACT_1_9.1
	ACT_1_9.2
	ACT_1_9.3
	>> clear_text
	-> stitch_10
= stitch_10
	~ currentStitch = 10
	ACT_1_10.1
	ACT_1_10.2
	ACT_1_10.3
	ACT_1_10.4
	ACT_1_10.5
	ACT_1_10.6
	>> clear_text
	>> sprite ronan army_tired middle
	-> stitch_11
= stitch_11
	~ currentStitch = 11
	ACT_1_11.1
	ACT_1_11.2
	ACT_1_11.3
	ACT_1_11.4
	ACT_1_11.5
	ACT_1_11.6
	ACT_1_11.7
	>> clear_text
	-> stitch_12
= stitch_12
	~ currentStitch = 12
	ACT_1_12.1
	ACT_1_12.2
	ACT_1_12.3
	ACT_1_12.4
	ACT_1_12.5
	ACT_1_12.6
	>> clear_text
	-> stitch_13
= stitch_13
	~ currentStitch = 13
	ACT_1_13.1
	ACT_1_13.2
	ACT_1_13.3
	ACT_1_13.4
	ACT_1_13.5
	ACT_1_13.6
	ACT_1_13.7
	>> sprite ronan army_smile middle
	-> stitch_14
= stitch_14
	~ currentStitch = 14
	ACT_1_14.1
	ACT_1_14.2
	ACT_1_14.3
	ACT_1_14.4
	ACT_1_14.5
	ACT_1_14.6
	>> clear_text
	-> stitch_15
= stitch_15
	~ currentStitch = 15
	ACT_1_15.1
	ACT_1_15.2
	>> clear_text
	-> stitch_16
= stitch_16
	~ currentStitch = 16
	ACT_1_16.1
	ACT_1_16.2
	ACT_1_16.3
	>> clear_text
	-> stitch_17
= stitch_17
	~ currentStitch = 17
	ACT_1_17.1
	ACT_1_17.2
	ACT_1_17.3
	ACT_1_17.4
	ACT_1_17.5
	>> clear_text
	-> stitch_18
= stitch_18
	~ currentStitch = 18
	ACT_1_18.1
	>> ost_off
	>> clear_all
	-> stitch_19
= stitch_19
	~ currentStitch = 19
	ACT_1_19.1
	>> clear_text
	-> Scene_2

== Scene_2 ==
	~ currentScene = 2
	>> change_bg office
	-> stitch_20
= stitch_20
	~ currentStitch = 20
	ACT_1_20.1
	ACT_1_20.2
	ACT_1_20.3
	ACT_1_20.4
	ACT_1_20.5
	ACT_1_20.6
	>> clear_text
	-> stitch_21
= stitch_21
	~ currentStitch = 21
	ACT_1_21.1
	ACT_1_21.2 #n
	-> stitch_22
= stitch_22
	~ currentStitch = 22
	ACT_1_22.1
	ACT_1_22.2
	ACT_1_22.3
	ACT_1_22.4
	ACT_1_22.5
	>> sprite ronan army_tired middle
	>> clear_text
	-> stitch_23
= stitch_23
	~ currentStitch = 23
	ACT_1_23.1
	ACT_1_23.2
	ACT_1_23.3
	ACT_1_23.4
	ACT_1_23.5
	>> clear_text
	-> stitch_24
= stitch_24
	~ currentStitch = 24
	ACT_1_24.1
	ACT_1_24.2
	>> clear_text
	-> stitch_25
= stitch_25
	~ currentStitch = 25
	ACT_1_25.1
	ACT_1_25.2
	ACT_1_25.3
	ACT_1_25.4 # n
	-> stitch_26
= stitch_26
	~ currentStitch = 26
	ACT_1_26.1
	ACT_1_26.2
	ACT_1_26.3
	>> clear_all
	>> sprite ronan army_tired left
	>> sprite rikki neutral right
	-> stitch_27
= stitch_27
	~ currentStitch = 27
	ACT_1_27.1
	ACT_1_27.2
	ACT_1_27.3
	ACT_1_27.4
	ACT_1_27.5
	>> clear_text
	-> stitch_28
= stitch_28
	~ currentStitch = 28
	ACT_1_28.1
	ACT_1_28.2
	ACT_1_28.3
	ACT_1_28.4
	ACT_1_28.5 # n
	-> stitch_29
= stitch_29
	~ currentStitch = 29
	ACT_1_29.1
	ACT_1_29.2
	ACT_1_29.3
	>> clear_text
	-> stitch_30
= stitch_30
	~ currentStitch = 30
	ACT_1_30.1
	>> clear_text
	-> stitch_31
= stitch_31
	~ currentStitch = 31
	ACT_1_31.1
	>> clear_text
	-> stitch_32
= stitch_32
	~ currentStitch = 32
	ACT_1_32.1
	ACT_1_32.2
	ACT_1_32.3
	ACT_1_32.4
	ACT_1_32.5
	ACT_1_32.6
	>> clear_text
	-> stitch_33
= stitch_33
	~ currentStitch = 33
	ACT_1_33.1
	ACT_1_33.2
	ACT_1_33.3
	ACT_1_33.4
	ACT_1_33.5
	>> clear_all
	>> change_bg black
	-> stitch_34
= stitch_34
	~ currentStitch = 34
	ACT_1_34.1
	ACT_1_34.2
	ACT_1_34.3
	ACT_1_34.4
	ACT_1_34.5
	ACT_1_34.6
	ACT_1_34.7
	>> clear_text
	-> stitch_35
= stitch_35
	~ currentStitch = 35
	ACT_1_35.1
	ACT_1_35.2 # i 
	ACT_1_35.3 # i
	ACT_1_35.4 # i # n
	ACT_1_35.5 # i
	ACT_1_35.6 # i
	ACT_1_35.7 # i
	ACT_1_35.8 # i
	ACT_1_35.9 # i # n
	-> stitch_36
= stitch_36
	~ currentStitch = 36
	ACT_1_36.1 # i
	>> clear_text
	-> stitch_37
= stitch_37
	~ currentStitch = 37
	ACT_1_37.1
	ACT_1_37.2
	ACT_1_37.3
	ACT_1_37.4
	>> clear_text
	-> stitch_38
= stitch_38
	~ currentStitch = 38
	ACT_1_38.1
	ACT_1_38.2
	ACT_1_38.3
	ACT_1_38.4
	ACT_1_38.5
	ACT_1_38.6
	ACT_1_38.7
	ACT_1_38.8
	ACT_1_38.9
	ACT_1_38.10
	>> clear_text
	-> stitch_39
= stitch_39
	~ currentStitch = 39
	ACT_1_39.1
	ACT_1_39.2
	ACT_1_39.3
	ACT_1_39.4 # n
	-> stitch_40
= stitch_40
	~ currentStitch = 40
	ACT_1_40.1
	ACT_1_40.2
	ACT_1_40.3
	ACT_1_40.4
	>> clear_text
	>> change_bg office
	>> sprite ronan army_tired left
	>> sprite rikki neutral right
	-> stitch_41
= stitch_41
	~ currentStitch = 41
	ACT_1_41.1
	ACT_1_41.2
	ACT_1_41.3
	>> clear_text
	-> stitch_42
= stitch_42
	~ currentStitch = 42
	ACT_1_42.1
	ACT_1_42.2
	ACT_1_42.3
	>> clear_text
	-> stitch_43
= stitch_43
	~ currentStitch = 43
	ACT_1_43.1
	ACT_1_43.2
	ACT_1_43.3 # n
	-> stitch_44
= stitch_44
	~ currentStitch = 44
	ACT_1_44.1
	ACT_1_44.2
	ACT_1_44.3
	ACT_1_44.4
	ACT_1_44.5
	ACT_1_44.6
	ACT_1_44.7
	>> clear_text
	-> stitch_45
= stitch_45
	~ currentStitch = 45
	ACT_1_45.1 # n
	ACT_1_45.2
	ACT_1_45.3
	ACT_1_45.4
	ACT_1_45.5
	ACT_1_45.6
	ACT_1_45.7
	ACT_1_45.8
	>> clear_text
	-> stitch_46
= stitch_46
	~ currentStitch = 46
	ACT_1_46.1
	ACT_1_46.2
	ACT_1_46.3
	>> clear_text
	-> stitch_47
= stitch_47
	~ currentStitch = 47
	ACT_1_47.1
	>> clear_text
	-> stitch_48
= stitch_48
	~ currentStitch = 48
	ACT_1_48.1
	>> clear_all
	>> sprite ronan army_tired middle
	-> stitch_49
= stitch_49
	~ currentStitch = 49
	ACT_1_49.1
	ACT_1_49.2
	ACT_1_49.3
	ACT_1_49.4
	>> clear_text
	-> stitch_50
= stitch_50
	~ currentStitch = 50
	ACT_1_50.1
	>> clear_text
	-> stitch_51
= stitch_51
	~ currentStitch = 51
	ACT_1_51.1 # n
	ACT_1_51.2 # n
	ACT_1_51.3
	ACT_1_51.4
	>> clear_text
	-> stitch_52
= stitch_52
	~ currentStitch = 52
	ACT_1_52.1
	ACT_1_52.2
	ACT_1_52.3
	ACT_1_52.4
	ACT_1_52.5
	ACT_1_52.6
	ACT_1_52.7
	>> clear_text
	-> stitch_53
= stitch_53
	~ currentStitch = 53
	ACT_1_53.1
	ACT_1_53.2
	ACT_1_53.3 # n
	ACT_1_53.4
	ACT_1_53.5
	>> clear_text
	-> stitch_54
= stitch_54
	~ currentStitch = 54
	ACT_1_54.1
	ACT_1_54.2 # n
	ACT_1_54.3
	ACT_1_54.4
	ACT_1_54.5
	>> clear_text
	-> stitch_55
= stitch_55
	~ currentStitch = 55
	ACT_1_55.1
	ACT_1_55.2
	ACT_1_55.3
	ACT_1_55.4
	>> clear_text
	>> sprite ronan army_smile middle
	-> stitch_56
= stitch_56
	~ currentStitch = 56
	ACT_1_56.1
	ACT_1_56.2
	ACT_1_56.3
	>> clear_text
	-> stitch_57
= stitch_57
	~ currentStitch = 57
	ACT_1_57.1
	ACT_1_57.2
	>> clear_text
	>> sprite ronan army_tired middle
	-> stitch_58
= stitch_58
	~ currentStitch = 58
	ACT_1_58.1
	ACT_1_58.2
	>> clear_text
	>> change_bg black
	-> stitch_59
= stitch_59
	~ currentStitch = 59
	ACT_1_59.1
	ACT_1_59.2
	ACT_1_59.3
	>> clear_text
	-> stitch_60
= stitch_60
	~ currentStitch = 60
	ACT_1_60.1
	ACT_1_60.2
	>> clear_text
	-> Scene_3

== Scene_3 ==
	~ currentScene = 3
	>> change_bg office
	>> sprite ronan army_tired middle
	-> stitch_61
= stitch_61
	~ currentStitch = 61
	ACT_1_61.1
	ACT_1_61.2
	ACT_1_61.3 # n
	-> stitch_62
= stitch_62
	~ currentStitch = 62
	ACT_1_62.1 # i # n
	ACT_1_62.1
	ACT_1_62.1
	-> stitch_63
= stitch_63
	~ currentStitch = 63
	ACT_1_63.1
	ACT_1_63.2
	ACT_1_63.3
	>> clear_text
	-> stitch_64
= stitch_64
	~ currentStitch = 64
	ACT_1_64.1
	>> clear_text
	-> stitch_65
= stitch_65
	~ currentStitch = 65
	ACT_1_65.1
	ACT_1_65.2
	ACT_1_65.3
	ACT_1_65.4
	ACT_1_65.5 # n
	ACT_1_65.6
	ACT_1_65.7 # n
	ACT_1_65.8
	ACT_1_65.9
	>> clear_text
	-> stitch_66
= stitch_66
	~ currentStitch = 66
	ACT_1_66.1
	ACT_1_66.2 # n
	ACT_1_66.3 # n
	ACT_1_66.4 # n
	ACT_1_66.5
	ACT_1_66.6
	>> clear_text
	-> stitch_67
= stitch_67
	~ currentStitch = 67
	ACT_1_67.1 # n
	ACT_1_67.2
	ACT_1_67.3
	ACT_1_67.4
	ACT_1_67.5
	ACT_1_67.6 # n
	ACT_1_67.7
	ACT_1_67.8
	ACT_1_67.9 # n
	ACT_1_67.10 # n
	ACT_1_67.11
	>> clear_text
	-> stitch_68
= stitch_68
	~ currentStitch = 68
	ACT_1_68.1
	ACT_1_68.2
	>> clear_text
	-> stitch_69
= stitch_69
	~ currentStitch = 69
	ACT_1_69.1 # n
	ACT_1_69.2
	ACT_1_69.3
	ACT_1_69.4
	ACT_1_69.5
	ACT_1_69.6
	ACT_1_69.7
	>> clear_text
	-> stitch_70
= stitch_70
	~ currentStitch = 70
	ACT_1_70.1
	ACT_1_70.2
	ACT_1_70.3
	>> clear_text
	-> stitch_71
= stitch_71
	~ currentStitch = 71
	ACT_1_71.1 # n
	ACT_1_71.2
	ACT_1_71.2
	ACT_1_71.5
	ACT_1_71.3 # n
	ACT_1_71.3
	ACT_1_71.3
	ACT_1_71.4
	>> clear_text
	-> stitch_72
= stitch_72
	~ currentStitch = 72
	ACT_1_72.1
	ACT_1_72.2
	ACT_1_72.3 # n
	ACT_1_72.4
	ACT_1_72.5
	ACT_1_72.6
	ACT_1_72.7
	ACT_1_72.8
	>> clear_text
	-> stitch_73
= stitch_73
	~ currentStitch = 73
	ACT_1_73.1
	ACT_1_73.2 # n
	ACT_1_73.3
	>> clear_text
	-> stitch_74
= stitch_74
	~ currentStitch = 74
	ACT_1_74.1
	ACT_1_74.2 # n
	ACT_1_74.3 # n
	ACT_1_74.4
	>> clear_text
	-> stitch_75
= stitch_75
	~ currentStitch = 75
	ACT_1_75.1
	ACT_1_75.2
	ACT_1_75.3
	ACT_1_75.4
	ACT_1_75.5
	ACT_1_75.6
	>> clear_all
	>> sprite ronan army_tired middle
	-> stitch_76
= stitch_76
	~ currentStitch = 76
	ACT_1_76.1 # n
	ACT_1_76.2 # n
	ACT_1_76.3 # n
	ACT_1_76.4
	>> clear_text
	-> stitch_77
= stitch_77
	~ currentStitch = 77
	ACT_1_77.1 # n
	ACT_1_77.2
	ACT_1_77.3
	ACT_1_77.4
	ACT_1_77.5
	ACT_1_77.6 # n
	ACT_1_77.7 # n
	ACT_1_77.8
	>> clear_text
	-> stitch_78
= stitch_78
	~ currentStitch = 78
	ACT_1_78.1 # n
	ACT_1_78.2 # n
	ACT_1_78.3
	ACT_1_78.4 # n
	ACT_1_78.5 # n
	ACT_1_78.6
	>> clear_text
	-> stitch_79
= stitch_79
	~ currentStitch = 79
	ACT_1_79.1
	ACT_1_79.2
	ACT_1_79.3 # n
	ACT_1_79.4
	>> clear_text
	-> stitch_80
= stitch_80
	~ currentStitch = 80
	ACT_1_80.1
	ACT_1_80.2 # n
	ACT_1_80.3 # n
	ACT_1_80.4
	>> clear_text
	-> stitch_81
= stitch_81
	~ currentStitch = 81
	ACT_1_81.1
	ACT_1_81.2
	ACT_1_81.3 # n
	ACT_1_81.4 # n
	ACT_1_81.5 # n
	ACT_1_81.6 # n
	ACT_1_81.7 # n
	ACT_1_81.8 # n
	ACT_1_81.9
	>> clear_all
	-> Scene_4

== Scene_4 ==
	~ currentScene = 4
	>> change_bg black
	>> sprite kaede smile middle
	-> stitch_82
= stitch_82
	~ currentStitch = 82
	ACT_1_82.1
	ACT_1_82.2
	ACT_1_82.3
	ACT_1_82.4
	>> clear_text
	-> stitch_83
= stitch_83
	~ currentStitch = 83
	ACT_1_83.1
	ACT_1_83.2
	ACT_1_83.3 # n
	ACT_1_83.4 # n
	ACT_1_83.5
	>> clear_all
	>> ost_on illness
	-> stitch_84
= stitch_84
	~ currentStitch = 84
	ACT_1_84.1 # red
	ACT_1_84.2 # red # n
	ACT_1_84.1 # red
	ACT_1_84.2 # red # n
	ACT_1_84.1 # red
	ACT_1_84.2 # red # n
	ACT_1_84.1 # red
	ACT_1_84.2 # red # n
	ACT_1_84.3 # red
	>> ost_off
	>> clear_text
	>> change_bg office
	>> screen_shake true
	>> sprite ronan army_tired middle
	>> screen_shake false
	-> stitch_85
= stitch_85
	~ currentStitch = 85
	ACT_1_85.1
	ACT_1_85.2 # n
	ACT_1_85.3 # n
	ACT_1_85.4
	>> clear_text
	-> stitch_86
= stitch_86
	~ currentStitch = 86
	ACT_1_86.1
	ACT_1_86.2
	>> clear_text
	-> stitch_87
= stitch_87
	~ currentStitch = 87
	ACT_1_87.1 # n
	ACT_1_87.2
	ACT_1_87.3
	>> clear_text
	-> stitch_88
= stitch_88
	~ currentStitch = 88
	ACT_1_88.1 # n
	ACT_1_88.2
	>> clear_all
	>> change_bg black
	-> stitch_89
= stitch_89
	~ currentStitch = 89
	ACT_1_89.1
	ACT_1_89.2
	ACT_1_89.3 # n
	ACT_1_89.4
	ACT_1_89.5
	>> clear_text
	-> stitch_90
= stitch_90
	~ currentStitch = 90
	ACT_1_90.1
	ACT_1_90.2
	ACT_1_90.3
	ACT_1_90.4
	ACT_1_90.5 # n
	ACT_1_90.6
	ACT_1_90.7
	ACT_1_90.8
	ACT_1_90.9
	ACT_1_90.10
	ACT_1_90.11
	ACT_1_90.12
	ACT_1_90.13
	ACT_1_90.14
	ACT_1_90.15
	ACT_1_90.16
	ACT_1_90.17 # n
	ACT_1_90.18
	>> clear_text
	>> change_bg office
	>> sprite ronan army_tired left
	>> sprite rikki neutral right
	-> stitch_91
= stitch_91
	~ currentStitch = 91
	ACT_1_91.1
	ACT_1_91.2 # n
	ACT_1_91.3
	>> clear_text
	-> stitch_92
= stitch_92
	~ currentStitch = 92
	ACT_1_92.1
	ACT_1_92.2
	ACT_1_92.3 # n
	ACT_1_92.4
	ACT_1_92.5
	>> clear_text
	-> stitch_93
= stitch_93
	~ currentStitch = 93
	ACT_1_93.1
	ACT_1_93.2
	ACT_1_93.3
	ACT_1_93.4
	ACT_1_93.5
	ACT_1_93.6
	ACT_1_93.7
	ACT_1_93.8
	>> clear_text
	-> stitch_94
= stitch_94
	~ currentStitch = 94
	ACT_1_94.1
	>> clear_text
	-> stitch_95
= stitch_95
	~ currentStitch = 95
	ACT_1_95.1
	ACT_1_95.2 # n
	ACT_1_95.3
	ACT_1_95.4
	ACT_1_95.5 # b
	ACT_1_95.6 # n
	ACT_1_95.7
	>> clear_text
	-> stitch_96
= stitch_96
	~ currentStitch = 96
	ACT_1_96.1
	ACT_1_96.2
	ACT_1_96.3
	ACT_1_96.4
	ACT_1_96.5 # n
	ACT_1_96.6
	ACT_1_96.7 # n
	ACT_1_96.8
	>> clear_text
	-> stitch_97
= stitch_97
	~ currentStitch = 97
	ACT_1_97.1
	>> clear_all
	>> change_bg black
	>> sprite kaede smile middle
	-> stitch_98
= stitch_98
	~ currentStitch = 98
	ACT_1_98.1
	>> clear_text
	-> stitch_99
= stitch_99
	~ currentStitch = 99
	ACT_1_99.1
	>> clear_all
	-> Scene_5

== Scene_5 ==
	~ currentScene = 5
	>> change_bg office
	-> stitch_100
= stitch_100
	~ currentStitch = 100
	ACT_1_100.1
	ACT_1_100.2
	ACT_1_100.3
	ACT_1_100.4
	ACT_1_100.5 # n
	ACT_1_100.6
	ACT_1_100.7
	>> clear_text
	-> stitch_101
= stitch_101
	~ currentStitch = 101
	ACT_1_101.1 # n
	ACT_1_101.2 # n
	ACT_1_101.3
	>> clear_text
	>> sprite ronan army_tired left
	>> sprite rikki neutral right
	-> stitch_102
= stitch_102
	~ currentStitch = 102
	ACT_1_102.1
	ACT_1_102.2 # n
	ACT_1_102.3
	>> clear_all
	>> disclaimer LAST_DISCLAIMER
	>> clear_text
	>> change_bg office
	-> stitch_103
= stitch_103
	~ currentStitch = 103
	ACT_1_103.1
	ACT_1_103.2
	ACT_1_103.3 # n
	ACT_1_103.4
	ACT_1_103.5 # n
	ACT_1_103.6
	ACT_1_103.7
	ACT_1_103.8 # n
	ACT_1_103.9
	ACT_1_103.10 # n
	ACT_1_103.11
	>> clear_text
	-> stitch_104
= stitch_104
	~ currentStitch = 104
	ACT_1_104.1
	ACT_1_104.2
	ACT_1_104.3
	ACT_1_104.4
	ACT_1_104.5
	ACT_1_104.6
	>> clear_text
	-> stitch_105
= stitch_105
	~ currentStitch = 105
	ACT_1_105.1
	ACT_1_105.2
	ACT_1_105.3
	ACT_1_105.4
	ACT_1_105.5
	ACT_1_105.6
	ACT_1_105.7
	>> clear_text
	-> stitch_106
= stitch_106
	~ currentStitch = 106
	ACT_1_106.1
	ACT_1_106.2 # n
	ACT_1_106.3
	ACT_1_106.4 # n
	ACT_1_106.5
	ACT_1_106.6
	>> clear_text
	-> stitch_107
= stitch_107
	~ currentStitch = 107
	ACT_1_107.1 # n
	ACT_1_107.2
	ACT_1_107.3
	>> clear_text
	-> stitch_108
= stitch_108
	~ currentStitch = 108
	ACT_1_108.1
	ACT_1_108.2
	ACT_1_108.3
	ACT_1_108.4
	ACT_1_108.5
	ACT_1_108.6
	ACT_1_108.7
	ACT_1_108.8 # n
	ACT_1_108.9
	ACT_1_108.10
	ACT_1_108.11
	ACT_1_108.12
	ACT_1_108.13
	>> clear_text
	-> stitch_109
= stitch_109
	~ currentStitch = 109
	ACT_1_109.1
	ACT_1_109.2
	ACT_1_109.3
	ACT_1_109.4
	ACT_1_109.5 # n
	ACT_1_109.6 # n
	ACT_1_109.7
	>> clear_text
	-> stitch_110
= stitch_110
	~ currentStitch = 110
	ACT_1_110.1 # n
	ACT_1_110.2
	ACT_1_110.3
	ACT_1_110.4 # n
	ACT_1_110.5 # n
	ACT_1_110.6 # n
	ACT_1_110.7
	>> clear_text
	-> stitch_111
= stitch_111
	~ currentStitch = 111
	ACT_1_111.1 # n
	ACT_1_111.2
	ACT_1_111.3
	ACT_1_111.4 # n
	ACT_1_111.5 # n
	ACT_1_111.6
	ACT_1_111.7
	ACT_1_111.8 # n
	ACT_1_111.9 # n
	ACT_1_111.10
	>> clear_text
	-> stitch_112
= stitch_112
	~ currentStitch = 112
	ACT_1_112.1
	ACT_1_112.2 # n
	ACT_1_112.3 # n
	ACT_1_112.4
	ACT_1_112.5
	ACT_1_112.6
	ACT_1_112.7
	>> clear_text
	-> stitch_113
= stitch_113
	~ currentStitch = 113
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	>> clear_text
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	>> clear_text
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	ACT_1_113.1 # red
	>> clear_text
	-> stitch_114
= stitch_114
	~ currentStitch = 114
	ACT_1_114.1
	ACT_1_114.2
	ACT_1_114.3
	ACT_1_114.4
	ACT_1_114.5
	>> clear_text
	-> stitch_115
= stitch_115
	~ currentStitch = 115
	ACT_1_115.1 # n
	ACT_1_115.2 # n
	ACT_1_115.3 # n
	ACT_1_115.4 # n
	ACT_1_115.5 # n
	ACT_1_115.6
	>> clear_text
	-> stitch_116
= stitch_116
	~ currentStitch = 116
	ACT_1_116.1
	ACT_1_116.2
	ACT_1_116.3
	ACT_1_116.4
	ACT_1_116.5
	ACT_1_116.6
	ACT_1_116.7
	ACT_1_116.8
	ACT_1_116.9
	ACT_1_116.10
	>> clear_text
	-> stitch_117
= stitch_117
	~ currentStitch = 117
	ACT_1_117.1 # n
	ACT_1_117.2 # n
	ACT_1_117.3
	>> clear_all
	>> sprite ronan army_tired middle
	-> stitch_118
= stitch_118
	~ currentStitch = 118
	ACT_1_118.1
	ACT_1_118.2
	ACT_1_118.3
	ACT_1_118.4
	>> clear_text
	-> stitch_119
= stitch_119
	~ currentStitch = 119
	ACT_1_119.1
	ACT_1_119.2 # n
	ACT_1_119.3
	ACT_1_119.4
	>> clear_text
	-> stitch_120
= stitch_120
	~ currentStitch = 120
	ACT_1_120.1
	ACT_1_120.2
	ACT_1_120.3
	ACT_1_120.4
	>> clear_text
	-> stitch_121
= stitch_121
	~ currentStitch = 121
	ACT_1_121.1
	ACT_1_121.2
	ACT_1_121.3
	ACT_1_121.4
	ACT_1_121.5
	ACT_1_121.6
	ACT_1_121.7
	ACT_1_121.8
	>> clear_text
	>> change_bg black
	-> stitch_122
= stitch_122
	~ currentStitch = 122
	ACT_1_122.1 # red
	>> clear_text
	>> change_bg office
	-> stitch_123
= stitch_123
	~ currentStitch = 123
	ACT_1_123.1 # n
	ACT_1_123.2
	ACT_1_123.3
	>> clear_text
	-> stitch_124
= stitch_124
	~ currentStitch = 124
	ACT_1_124.1
	ACT_1_124.2
	ACT_1_124.3
	>> clear_all
	>> change_bg black
	-> stitch_125
= stitch_125
	~ currentStitch = 125
	ACT_1_125.1
	>> sprite kaede smile middle
	-> stitch_126
= stitch_126
	~ currentStitch = 126
	ACT_1_126.1
	>> clear_all
-> Scene_6